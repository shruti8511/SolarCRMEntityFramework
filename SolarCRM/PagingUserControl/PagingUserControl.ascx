<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PagingUserControl.ascx.cs" Inherits="SolarCRM.PagingUserControl.PagingUserControl" %>
<div class="row">
    <div class="col-sm-5">
    </div>
    <div class="col-sm-7">
        <div class="dataTables_paginate paging_simple_numbers" id="example1_paginate">
            <ul class="pagination">
                <li class="paginate_button previous" id="example1_previous">
                    <asp:LinkButton ID="lnkPrevious" runat="server" Text="Previous" OnClick="lnkPrevious_Click"></asp:LinkButton></li>
                <li class="paginate_button ">
                    <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand"
                        OnItemDataBound="rptPaging_ItemDataBound">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkPageNo" runat="server" Text='<%# Container.DataItem %>' CommandName="ChangePage"
                                CommandArgument='<%# Container.DataItem %>'>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </li>
               
                <li class="paginate_button next" id="example1_next">
                    <asp:LinkButton ID="lnkNext" runat="server" Text="Next" OnClick="lnkNext_Click"
                        CssClass="pagebtn"></asp:LinkButton></li>
            </ul>
        </div>
    </div>
</div>

<div class="cboth">
</div>
