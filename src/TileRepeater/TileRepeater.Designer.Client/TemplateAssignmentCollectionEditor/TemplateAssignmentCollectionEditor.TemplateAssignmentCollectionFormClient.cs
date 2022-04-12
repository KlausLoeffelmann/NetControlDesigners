using Microsoft.DotNet.DesignTools.Client.Proxies;
using Microsoft.DotNet.DesignTools.Client.Views;
using System;
using System.Diagnostics;
using System.Linq;
using WinForms.Tiles.Designer.Protocol.Endpoints;

namespace WinForms.Tiles.Designer.Client
{
    internal partial class TemplateAssignmentCollectionEditor
    {
        private partial class TemplateAssignmentCollectionFormClient : ViewModelClient
        {
            private readonly AddTemplateAssignmentItemEndpoint.Sender _addTemplateAssignmentItem;
            private readonly GetTemplateAssignmentItemsEndpoint.Sender _getTemplateAssignmentItems;
            private readonly GetUpdatedTemplateAssignmentItemEndpoint.Sender _getUpdatedTemplateAssignmentItem;
            private readonly TemplateAssignmentCollectionEditorOKClickEndpoint.Sender _okClick;
            private readonly RemoveTemplateAssignmentItemEndpoint.Sender _removeTemplateAssignmentItem;

            public TemplateAssignmentCollectionFormClient(ObjectProxy viewModel)
                : base(viewModel)
            {
                if (Client is null)
                {
                    throw new NullReferenceException($"{nameof(Client)} cannot be null.");
                }

                _addTemplateAssignmentItem = Client.Protocol.GetEndpoint<AddTemplateAssignmentItemEndpoint>().GetSender(Client);
                _getTemplateAssignmentItems = Client.Protocol.GetEndpoint<GetTemplateAssignmentItemsEndpoint>().GetSender(Client);
                _getUpdatedTemplateAssignmentItem = Client.Protocol.GetEndpoint<GetUpdatedTemplateAssignmentItemEndpoint>().GetSender(Client);
                _okClick = Client.Protocol.GetEndpoint<TemplateAssignmentCollectionEditorOKClickEndpoint>().GetSender(Client);
                _removeTemplateAssignmentItem = Client.Protocol.GetEndpoint<RemoveTemplateAssignmentItemEndpoint>().GetSender(Client);
            }

            public TemplateAssignmentItem AddItem()
            {
                var response = _addTemplateAssignmentItem.SendRequest(new AddTemplateAssignmentItemRequest(ViewModelProxy));

                return TemplateAssignmentItem.FromData(response.Item);
            }

            public TemplateAssignmentItem[] GetItems()
            {
                if (Debugger.IsAttached)
                    Debugger.Break();
                
                var response = _getTemplateAssignmentItems.SendRequest(new GetTemplateAssignmentItemsRequest(ViewModelProxy));

                return response.Items
                    .Select(i => TemplateAssignmentItem.FromData(i))
                    .ToArray();
            }

            public TemplateAssignmentItem GetUpdatedItem(int index)
            {
                var response = _getUpdatedTemplateAssignmentItem.SendRequest(new GetUpdatedTemplateAssignmentItemRequest(ViewModelProxy, index));

                return TemplateAssignmentItem.FromData(response.Item);
            }

            public void OKClick()
            {
                _okClick.SendRequest(new TemplateAssignmentCollectionEditorOKClickRequest(ViewModelProxy));
            }

            public void RemoveItem(int index)
            {
                _removeTemplateAssignmentItem.SendRequest(new RemoveTemplateAssignmentItemRequest(ViewModelProxy, index));
            }
        }
    }
}
