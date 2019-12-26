<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="SolarCRM.mailtemplate.Invoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
<body>
    <div style="width: 100%;">
        <div style="width: 960px; margin: 0px auto;">
            <div style="clear: both; font-family: 'Arial'; font-size: 18px;">
            </div>
            <div style="font-family: 'Arial'; font-size: 18px;">

                <h3 style="text-align: center; font-family: 'Arial'; margin: 5px;">
                    <asp:Label ID="lblTaxTitle" runat="server" Visible="False"></asp:Label>
                </h3>


                <div style="font-family: 'Arial'; font-size: 18px;">

                    <table align="center" width="100%" border="0" cellspacing="0" cellpadding="0" style="border-left: solid 1px #000; border-collapse: collapse; border-top: 1px solid #000; font-size: 16px;">
                        <tr>
                            <td colspan="2" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                <strong>Solcells Energy</strong><br />
                                <p>
                                    B/4/91<br />
                                    Vinit Khand Gomatinagar<br />
                                    Lucknow<br />
                                    GSTIN/UIN: 09ACXFS1861L1Z7<br />
                                    State Name : Uttar Pradesh, Code : 09<br />
                                    E-Mail : info@solcellsenergy.com<br />
                                </p>

                                <br />
                                <br />
                            </td>
                            <td>
                                 <table align="center" width="100%" border="0" cellspacing="0" cellpadding="0" style="border-left: solid 1px #000; border-collapse: collapse; border-top: 1px solid #000; border-bottom: 1px solid #000; font-size: 16px; margin-top: 0px;">
                                    <tr>
                                        <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                            <strong>Invoice No :</strong><asp:Label ID="lblManualInvoiceNumber" runat="server"></asp:Label>
                                        </td>

                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2" align="left" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                            <strong>Delivery Note</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2" align="left" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                            <strong>Supplier’s Ref.</strong>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2" align="left" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                            <strong>Buyer’s Order No.</strong>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2" align="left" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                            <strong>Despatch Document No.</strong>
                                    </tr>
                                    <tr>

                                        <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                            <strong>Dispatched Through :  Road</strong>
                                        </td>

                                    </tr>
                                </table>
                            </td>


                            <td>

                                 <table align="center" width="100%" border="0" cellspacing="0" cellpadding="0" style="border-left: solid 1px #000;border-bottom: 1px solid #000; border-collapse: collapse; border-top: 1px solid #000; font-size: 16px;">
                                    <tr>
                                        <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                            <strong>Dated : </strong>
                                            <asp:Label ID="lblDate" runat="server"></asp:Label><br />

                                        </td>

                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2" align="left" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                            <strong>Mode/Terms of Payment</strong>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2" align="left" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                            <strong>Other Reference(s)</strong>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2" align="left" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                            <strong>Dated</strong>
                                    </tr>
                                    <tr>
                                        <td align="left" valign="top" colspan="2" align="left" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                            <strong>Delivery Note Date</strong>
                                    </tr>
                                    <tr>

                                        <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                            <strong>Destination</strong>
                                        </td>

                                    </tr>
                                </table>
                            </td>






                        </tr>
                        <tr>
                            <td colspan="2" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                <strong>Buyer</strong><br />
                                <asp:Label ID="lblContact" runat="server"></asp:Label><br />
                                <asp:Label ID="lblPostalAddress" runat="server"></asp:Label><br />
                                <asp:Label ID="lblPostalAddress2" runat="server"></asp:Label><br />
                                <asp:Label ID="Label1" runat="server" Text="State Code :"></asp:Label>
                                <asp:Label ID="lblStateCode" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="Label2" runat="server" Text="Place of Supply : "></asp:Label>
                                <asp:Label ID="lblPlaceofSupply" runat="server"></asp:Label><br />
                                <asp:Label ID="Label7" runat="server" Text="GST No : "></asp:Label>
                                <asp:Label ID="lblGSTNumber" runat="server"></asp:Label>
                                <br />
                                <br />
                                <strong>Delivery Address :</strong><br />
                                <asp:Label ID="lblDeliveryAddress" runat="server"></asp:Label>
                                <br />
                                <br />
                            </td>




                            <td colspan="2" align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                <strong>Terms of Delivery</strong>
                            </td>


                        </tr>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-left: solid 1px #999; border-top: 1px solid #999;">

                        <tr>
                            <%--  <td rowspan="10" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                <strong>Buyer</strong><br />
                                <asp:Label ID="lblContact" runat="server"></asp:Label><br />
                                <asp:Label ID="lblPostalAddress" runat="server"></asp:Label><br />
                                <asp:Label ID="lblPostalAddress2" runat="server"></asp:Label><br />
                                <asp:Label ID="Label1" runat="server" Text="State Code :"></asp:Label>
                                <asp:Label ID="lblStateCode" runat="server"></asp:Label>
                                <br />
                                <asp:Label ID="Label2" runat="server" Text="Place of Supply : "></asp:Label>
                                <asp:Label ID="lblPlaceofSupply" runat="server"></asp:Label><br />
                                <asp:Label ID="Label7" runat="server" Text="GST No : "></asp:Label>
                                <asp:Label ID="lblGSTNumber" runat="server"></asp:Label>
                                <br />
                                <br />
                                <strong>Delivery Address :</strong><br />
                                <asp:Label ID="lblDeliveryAddress" runat="server"></asp:Label>
                                <br />
                                <br />
                            </td>--%>
                        </tr>

                        <%-- <tr>
                            <td rowspan="9" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                <strong>Supplier</strong><br />
                                <p>
                                    E Solar CRM<br />
                                    A-802, Ganesh Plaza,<br />
                                    Nr. Navarangpura Post Office,<br />
                                    Navrangpura,<br />
                                    Ahmedabad, Gujarat ,India<br />
                                    GST No. : 
                                    <br />
                                    State Code : 
                                </p>

                                <br />
                                <br />
                            </td>
                        </tr>--%>

                        <%--                        <tr>
                            <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                <strong>Dated : </strong>
                                <asp:Label ID="lblDate" runat="server"></asp:Label><br />

                            </td>
                        </tr>--%>

                        <%-- <tr>
                            <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                <strong>Invoice No :</strong><asp:Label ID="lblManualInvoiceNumber" runat="server"></asp:Label>
                            </td>
                        </tr>--%>

                        <%-- <tr>
                            <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                <strong>Dispatched Through :  Road</strong>
                            </td>
                        </tr>--%>

                        <%--  <tr>
                            <td align="left" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                <strong>Delivery Date </strong>
                            </td>
                        </tr>--%>

                        <%-- <tr>
                            <td align="left" valign="top" colspan="2" rowspan="7" align="left" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                <strong>Delivery Note</strong>
                            </td>
                        </tr>--%>
                    </table>


                    <br />


                    <table align="center" width="100%" border="0" cellspacing="0" cellpadding="0" style="border-left: solid 1px #000; border-collapse: collapse; border-top: 1px solid #000; font-size: 16px;">

                        <tr>
                            <td width="5%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px; padding: 10px;">
                                <strong>Sr.no</strong>
                            </td>
                            <td width="40%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Description of Goods</strong>
                            </td>
                            <td width="15%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>HSN/SAC</strong>
                            </td>
                            <td width="15%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>GST Rate</strong>
                            </td>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Quantity (KW)</strong>
                            </td>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Rate Per Unit</strong>
                            </td>
                            <td width="5%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Unit</strong>
                            </td>
                            <td width="5%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Disc.</strong>
                            </td>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Taxable Value Amount (INR)</strong>
                            </td>
                        </tr>

                        <tr>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px; padding: 10px;">
                                <strong>1</strong>
                            </td>
                            <td style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Solar Power Generating System
                                 <br />
                                </strong>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong></strong>
                            </td>
<td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;"></td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblInstalledCapacity" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblRate" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>KWP</strong>
                            </td>
                            <td width="5%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong></strong>
                            </td>

                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblValue" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px; padding: 10px;">
                                <strong>2</strong>
                            </td>
                            <td style="text-align: right; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>CGST OUTPUT@2.5%
                                 <br />
                                </strong>
                            </td>

                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong></strong>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;"></td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;"></td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>
                                    <asp:Label ID="lblCGSTPer" runat="server"></asp:Label></strong></td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>%</strong>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;"></td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblCGST" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px; padding: 10px;">
                                <strong>3</strong>
                            </td>
                            <td style="text-align: right; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>SGST OUTPUT@2.5%
                                 <br />
                                </strong>
                            </td>

                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong></strong>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;"></td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;"></td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>
                                    <asp:Label ID="lblSGSTPer" runat="server"></asp:Label></strong></td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>%</strong>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;"></td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblSGST" runat="server"></asp:Label>
                            </td>
                        </tr>


                        <tr>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px; padding: 10px;">
                                <strong>4</strong>
                            </td>
                            <td style="text-align: right; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>IGST OUTPUT@5%
                                 <br />
                                </strong>
                            </td>

                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong></strong>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;"></td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;"></td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>
                                    <asp:Label ID="lblIGSTPer" runat="server"></asp:Label></strong></td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>%</strong>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;"></td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblIGST" runat="server"></asp:Label>
                            </td>
                        </tr>



                        <tr>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px; padding: 10px;">
                                <strong>5</strong>
                            </td>
                            <td style="text-align: right; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Invoice Value
                                 <br />
                                </strong>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong></strong>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;"></td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblTotalInstalledCapacity" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong></strong></td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong></strong>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;"></td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <%-- <img src="<%=MakeImageSrcData( Request.PhysicalApplicationPath+"/images/rupee.png") %>" width="8" height="14" algn="absmiddle" />--%>
                                <asp:Label ID="lblTotalCost" runat="server"></asp:Label>
                            </td>
                        </tr>

                    </table>

                    <br />
                    <p>
                        Invoice Value (in word) :
                                    <asp:Label ID="lblAmountInWord" runat="server"></asp:Label>
                    </p>

                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-left: solid 1px #999; border-top: 1px solid #999;">

                        <tr>


                            <td rowspan="2" align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">HSN/SAC</td>
                            <td rowspan="2" align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">Taxable Value</td>
                            <td colspan="2" align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">Central Tax</td>
                            <td colspan="2" align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">State Tax</td>
                            <td rowspan="2" align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">Total Tax Amount</td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">Rate</td>
                            <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">Amount</td>
                            <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">Rate</td>
                            <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">Amount</td>
                        </tr>
                        <tr>
                            <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;"></td>
                            <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;"></td>

                            <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;"></td>

                            <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                <asp:Label ID="lblCGSTTax" runat="server"></asp:Label>
                            </td>

                            <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;"></td>

                            <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;">
                                <asp:Label ID="lblSGSTTax" runat="server"></asp:Label>
                            </td>

                            <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;"></td>

                        </tr>
                       <%-- <tr>
                            <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;"></td>

                            <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;"></td>
                            <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;"></td>
                            <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;"></td>
                            <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;"></td>
                            <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;"></td>
                            <td align="left" valign="top" style="border-right: solid 1px #999; border-bottom: solid 1px #999; border-collapse: collapse; padding: 5px;"></td>

                        </tr>--%>
                    </table>
                    <asp:Label ID="lblIGSTTax" runat="server" Visible="False"></asp:Label>




                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="50%" align="left" style="border-collapse: collapse; font-family: Arial; font-size: 15px;">
                                <p>Company’s VAT TIN : 09850048065<br />
                                Company’s PAN : ACXFS1861L<br /><br />
                                Declaration<br />
We declare that this invoice shows the actual price of the
goods described and that all particulars are true and correct.</p>

                            </td>
                            <td width="50%" align="right" valign="top" style="border-collapse: collapse;">
                                <strong>for Solcells Energy</strong>
                                <br />
                                <br />
                                <br />
                                <br />
                                <strong>Authorised Signatory</strong>
                            </td>

                        </tr>

                    </table>
                    <br />


                    <br />

                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="100%" align="center" style="border-collapse: collapse; font-family: Arial; font-size: 15px;">

                                <p>This is a Computer Generated Invoice</p>
                            </td>
                        </tr>
                    </table>

                    <br />


                </div>
            </div>
        </div>
    </div>





</body>
</html>
