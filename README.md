# NetControlDesigners - Developing Custom Controls for the new WinForms Designer

The new Windows Forms (WinForms) .NET Designer needs a new SDK for authoring
Custom ControlDesigners. The necessary migration of Custom ControlDesigners from
.NET Framework to .NET is straight forward. Only UI-intensive design time
experience, such as custom dialogs requires custom code. This blog post shows,
what work is necessary to migrate WinForms ControlDesigners from .NET Framework
designer model to .NET designer model.

## The Demo scenario – the WinForms TileRepeater Control

If you ever developed in WPF, then you probably like, and in WinForms, miss a
feature, which is really useful in list binding scenarios: `DataTemplates` and
`DataTemplateSelectors`. Imagine, you have a list of elements as a data
source, each deriving from the same base type. For example, an
`ImageItem`, which holds a path to an image on disk. And from those you derive
an `PortraitImageItem` and a `LandscapeImageItem`. Now, you bind this list
to a List control, which will pick as the renderer for each item a WinForms
user control based on the type of the item you want to bind. In the sample, on
binding this control will instantiate a respective user control for showing
images in portrait format, and user controls for showing images in landscape
format. By choosing the right inheritance hierarchy, even introducing a
Separator item for grouping those user controls, for example
by months, is easily possible.

This is, what this sample is about. And using this control at runtime looks like
this:

![TileRepeaterDemo](https://github.com/KlausLoeffelmann/NetControlDesigners/blob/main/src/Resources/TileRepeaterDemo.gif)

**DISCLAIMER**: The control is a demo for the specific .NET WinForms Designer
scenario. It is not something that we suggest to use in a real-live environment.
For example, it lacks a virtual rendering mode, so, it uses up a Window Handle
for every element it shows. It works fine for up to 500 elements. But by all
means: It's a good start point for getting engaged, and this control has
certainly the potential to be extended in all different directions!

## The challenge

For making the `TileRepeater` control work at design time in a useful way, we
need to implement proper WinForms Designer support. Especially for this control:
with the new .NET Designer which requires  separate processes for the Visual
Studio .NET Framework client-based UI functionality on the one and the actual
.NET Forms and Control instantiation, management and rendering in a dedicated
Server process on the other side, authoring ControlDesigners has become a bit
tricky, when at least one of the controls needs a dedicated, custom UI. Compared
to the Framework Designer, this is a breaking change when you need to implement
custom .NET type editors, which are responsible the handle this type of UI. And
here is why:

When we want, for the example of this scenario, to show a modal Dialog, which
allows the user to pick the types for the data template selection (so, which
item type of the data source list to bind should result in what UserControl to
render), we have to deal with the different processes: The Visual Studio Process
runs in .NET Framework. But the actual control, which we are showing the custom
UI for, runs in the dedicated .NET server process: If your WinForms project,
which is using the control, is targeting .NET Core 3.1, then that process runs
.NET Core 3.1; if you target 6.0, the Server Process runs against .NET 6.0, and
so on. That is necessary, because you need and use types only the specific
version of .NET, you're targeting your WinForms App against, knows about. The
Visual Studio, .NET Framework-based client process is simply not able to
discover nor handle those newer .NET types. It simply doesn’t know them. From
that fact arises the actual challenge: Since the Control Designer’s dialogs are
also running in the context of .NET Framework, it cannot simply search for the
types (in our example neither both the items to bind and the resulting
UserControl types) it is supposed to offer the user in that dialog. Rather, the
.NET Framework part of the type editor needs to ask the .NET Process for those
types, and then it uses helper transport classes to get those types
cross-process back to the Framework based Visual Studio process. It can now
process the user’s input and send the results back to the server process. And
yes, that’s a change from the previous .NET Framework-only Control Designers,
and it involves indeed some refactoring of the design time code, but _only_ if
there _is_ an actual UI which needs to be shown on top of the UI that is
presented in the context of your actual control. Here is what that means
exactly:

- If you're control requires a UI, which is based on a type-converter and
  therefore shown in the context of the Property grid (like Enums or dedicated
  items to show in a property grid’s property grid cell ComboBox), your UI will
  be supported by the new designer model out of the box.

- If you're control requires a UI, which shows up as part of the control (like
  custom painted adorners or Action Lists) at design time, then you would need
  to write your control library against the WinForms Designer SDK, but you don’t
  need to roundtrip data to the Server process. Everything from the Developer’s
  perspective seems to actually be done server-side, and you can reuse most of
  the existing Control Designer Code. Note though, that you need to target it
  against the Windows Designer SDK.

- If you have custom type editors, however, which are displaying dedicated modal
  dialogs, then there is some rewriting effort involved for round-tripping the
  required data between the two processes.

- If you have type editors which are derived from existing type editors (like
  `ColorEditor` or `FileNameEditor`) for editing certain types of values for
  existing controls in .NET Framework, then you _also_ need the client/server
approach. That said, your control designer solution most probably doesn't need
to have extra communication code to exchange data between the server and the
client process. As long as you do not change the type the original editor is
handling, the Designer should be able to handle the necessary communication
behind the covers. But: That communication is still required to happen, and the
modified (inherited) editor types still need to be run in the context of Visual
Studio - which at this time is either the 32-Bit Framework process (VS 2019) or
the 64-bit Framework process (VS 2022).

- If you however just _use_ the editors (which again need to be provided by the
  client process), a server-only Control Designer suffices. In that case though,
  you need to state the types as strings, and cannot use `typeof` (in C#) or
  `GetType` (in VB). It would look something like this:

```CS
[Editor("System.Windows.Forms.Design.FileNameEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
        "System.Drawing.Design.UITypeEditor, System.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
public string? Filename { get; set; }
```

## Two sample Versions and the why

We already discussed, that different Controls might need different kind of UIs.
When you use only stock editors,  you just need your Control Designer to provide
custom Adorner painting, Action Lists or custom CodeDOM serializers, a
Server-only version for the Designer will do, and that is pretty much the way,
you developed in .NET Framework. Only if your Control or your Control Library
needs custom UI Type Editors, then you need a Client/Server-solution for your
Control library. That is the reason, the sample app contains two versions of the
control: One Control plus its Designer, which is the somewhat simplified version
of the sample, and which just comes with a custom type converter for assigning
just one `TileContent` user control as the renderer for each item. This one is
called `SimpleTileRepeater`. It just needs its Control Designer code next to the
actual Control’s implementation in one assembly/project, and from the
developer's perspective, everything needed at design times just happens in the
server-process.

![SimpleTileRepeater](https://github.com/KlausLoeffelmann/NetControlDesigners/blob/main/src/Resources/SimpleTileRepeaterActionList.gif)

The second Control is the actual full blown `TileRepeater` control and has
next to everything the `SimpleTileRepeater` has, but also the UI for the
Collection Editor, which allows the user to make a whole list of `TypeAssignments`.
And then, the UI for doing one of the assignments of that list of course is
again a dedicated Type Editor, which needs to be implemented in the way just
described. These type of control designer UIs require the most work.

![TileRepeater](https://github.com/KlausLoeffelmann/NetControlDesigners/blob/main/src/Resources/TileRepeaterActionList.gif)

## To make the sample compile

Please note: To make this demo compile, you need to add the output of the package project, which gets build into the folder,

```
NetControlDesigners\src\TileRepeater\NuGet\BuildOut
```

as a package source:

![image](https://user-images.githubusercontent.com/9663150/156468092-46e6087f-5a2f-4928-9398-e3fe859dc5c2.png)
