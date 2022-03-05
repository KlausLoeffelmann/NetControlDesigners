using Microsoft.DotNet.DesignTools.Client.Proxies;
using Microsoft.DotNet.DesignTools.Client.Views;
using System;
using System.Linq;
using WinForms.Tiles.Designer.Protocol.Endpoints;

namespace WinForms.Tiles.Designer.Client
{
    internal partial class TemplateAssignmentCollectionEditor
    {
        private partial class TemplateAssignmentCollectionFormClient : ViewModelClient
        {
            private readonly AddTemplateAssignmentItemEndpoint.Sender _addPersonItem;
            private readonly GetTemplateAssignmentItemsEndpoint.Sender _getPeopleItems;
            private readonly GetUpdatedTemplateAssignmentItemEndpoint.Sender _getUpdatedPersonItem;
            private readonly TemplateAssignmentCollectionEditorOKClickEndpoint.Sender _okClick;
            private readonly RemoveTemplateAssignmentItemEndpoint.Sender _removePersonItem;

            public TemplateAssignmentCollectionFormClient(ObjectProxy viewModel)
                : base(viewModel)
            {
                if (Client is null)
                {
                    throw new NullReferenceException($"{nameof(Client)} cannot be null.");
                }

                _addPersonItem = Client.Protocol.GetEndpoint<AddTemplateAssignmentItemEndpoint>().GetSender(Client);
                _getPeopleItems = Client.Protocol.GetEndpoint<GetTemplateAssignmentItemsEndpoint>().GetSender(Client);
                _getUpdatedPersonItem = Client.Protocol.GetEndpoint<GetUpdatedTemplateAssignmentItemEndpoint>().GetSender(Client);
                _okClick = Client.Protocol.GetEndpoint<TemplateAssignmentCollectionEditorOKClickEndpoint>().GetSender(Client);
                _removePersonItem = Client.Protocol.GetEndpoint<RemoveTemplateAssignmentItemEndpoint>().GetSender(Client);
            }

            public TemplateAssignmentItem AddItem()
            {
                var response = _addPersonItem.SendRequest(new AddTemplateAssignmentItemRequest(ViewModelProxy));

                return TemplateAssignmentItem.FromData(response.Item);
            }

            public TemplateAssignmentItem[] GetItems()
            {
                var response = _getPeopleItems.SendRequest(new GetTemplateAssignmentItemsRequest(ViewModelProxy));

                return response.Items
                    .Select(i => TemplateAssignmentItem.FromData(i))
                    .ToArray();
            }

            public TemplateAssignmentItem GetUpdatedItem(int index)
            {
                var response = _getUpdatedPersonItem.SendRequest(new GetUpdatedTemplateAssignmentItemRequest(ViewModelProxy, index));

                return TemplateAssignmentItem.FromData(response.Item);
            }

            public void OKClick()
            {
                _okClick.SendRequest(new TemplateAssignmentCollectionEditorOKClickRequest(ViewModelProxy));
            }

            public void RemoveItem(int index)
            {
                _removePersonItem.SendRequest(new RemoveTemplateAssignmentItemRequest(ViewModelProxy, index));
            }
        }
    }
}
