# NetControlDesigners - Developing Custom Controls for the new WinForms Designer

The new Windows Forms (WinForms) .NET Designer needs a dedicated SDK for
authoring Custom Control Designers. The necessary migration of WinForms Control
Designers from .NET Framework to .NET is straight forward. Only UI-intensive
Designers which custom Dialogs need to be rewritten. This blog post shows, what
work is necessary to migration WinForms Control Designers from .NET Framework to
.NET.

## The Demo scenario – the WinForms TileRepeater Control

If you ever developed in WPF, then you probably like and in WinForms miss a
feature, which is really useful in list binding scenarios: `DataTemplates` and
`DataTemplateSelectors`. Imagine, you have a list of elements as a data
source, each of which deriving from the same base type. For example, an
`ImageItem`, which hold a path to an image on disk. And from those you derive
an `PortraitImageItem` and a `LandscapeImageItem`. Now, you bind this list
against a List control, which will pick as the renderer for each item a WinForms
user control based on the type of the item you want to bind. In the sample, on
binding this control will instantiate a respective user control for showing
images in portrait format, and user controls for showing images in landscape
format. By choosing the right inheritance hierarchy, even introducing a
separator Item for grouping those user controls in a meaningful way, for example
by months is easily possible.

This is, what this sample is about. And using this control at runtime looks like
this:

![TileRepeaterDemo](https://github.com/KlausLoeffelmann/NetControlDesigners/blob/main/src/Resources/TileRepeaterDemo.gif)

## The challenge

For making the `TileRepeater` control work at design time in a useful way, we
need proper WinForms Designer support. Especially for this control: with the new
.NET Designer which comes with separate processes for the Visual Studio .NET
Framework client-based UI functionality on the one and the actual .NET Forms and
Control instantiation, management and rendering in a dedicated Server process on
the other side, authoring Control Designers has become a bit tricky. It is
compared to the Framework Designer a breaking change when you need to implement
custom .NET type editors. And here is why:

When we want to show a Dialog for example, which allows the user to pick the
types for the data template selection (so, which item type of the list to bind
should result in what UserControl to render), we have to deal with two different
processes: The Visual Studio Process runs in .NET Framework. But the actual
control, which we are showing the custom UI for, runs in the dedicated .NET
server process: If you target .NET Core 3.1, it runs .NET Core 3.1, if you
target 6.0, it runs 6.0 and so on. That’s necessary, because you need the types
only .NET knows about. The Visual Studio .NET Framework based client process is
simply not able to deal with all the new .NET types. It simply doesn’t know
them. So, from that fact arises the actual challenge: Since the Control
Designer’s dialogs are therefore also running in the context of .NET Framework,
it cannot simply search for the types (in our example neither both the items to
bind and the resulting UserControl types) it is supposed to offer the user in
that dialog. Rather, the .NET Framework part of the type editor needs to ask the
.NET Process for those types, and then it needs to use helper transport classes
to get those types cross-process back to the Framework based Visual Studio
process. It can now process the user’s input and send the results back to the
server process. And yes, that’s a change from the previous .NET Framework-only
Control Designers, and it involves indeed some rewriting of the Designer Code,
but only if there *is* an actual UI which needs to be shown on top of the UI
that is presented in the context of your actual control. Here is what that means
exactly:

-   If you just have an UI, which is based on a type-converter and therefore
    shown in the context of the Property grid (like Enums or dedicated items to
    show in a property grid’s property grid cell ComboBox), you are good to go
    as your current Control Designer are.

-   If you have an UI, which is part of the control (like custom painted
    adorners or Action Lists), then you would need to write your control library
    against the WinForms Designer SDK, but you don’t need to roundtrip data to
    the Server process. Everything from the Developer’s perspective seems to
    actually be done server-side, and you can reuse most of the existing Control
    Designer Code, but just need to target it against the Windows Designer SDK.

-   If you have custom type editors, however, which are displaying dedicated
    modal dialogs, then there is some rewriting effort involved for
    roundtripping the required data between the two processes.

## Two sample Versions and the why

The sample app contains those two versions: One Control plus its Designer, which
is the simplified version of the sample, and which just comes with a custom type
converter for assigning just one `TileContent` user control as the renderer
for each item. This one is called `SimpleTileRepeater`. It just needs its
Control Designer code next to the actual Control’s implementation in one
assembly/project.

![SimpleTileRepeater](https://github.com/KlausLoeffelmann/NetControlDesigners/blob/main/src/Resources/SimpleTileRepeaterActionList.gif)

The second Control is the actual full blown `TileRepeater` control and has
next to everything the `SimpleTileRepeater` has, also the UI for the
Collection Editor, which allows the user to make a list of `TypeAssignments`.
And then, the UI for doing one of the assignments of that list of course is
again a dedicated Type Editor, which needs to be implemented in the way just
described.

![TileRepeater](https://github.com/KlausLoeffelmann/NetControlDesigners/blob/main/src/Resources/TileRepeaterDemo.gif)


## To make the sample compile

Please note: To make this demo compile, you need to add the output of the package project, which gets build into the folder,

```
NetControlDesigners\src\TileRepeater\NuGet\BuildOut
```

as a package source:

![image](https://user-images.githubusercontent.com/9663150/156468092-46e6087f-5a2f-4928-9398-e3fe859dc5c2.png)
