<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Quotation.aspx.cs" Inherits="SolarCRM.mailtemplate.Quotation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">

    <style type="text/css">
        .grayback {
            color: #FFFFFF;
            background-color: #808080;
        }

        .lblpromo2note {
            padding-left: 10px;
        }
        .auto-style1 {
            height: 105px;
        }
    </style>
</head>

<body>

    <div style="width: 100%;" align="center">

        <div style="width: 100%; margin: 0px auto;">

            <div style="clear: both; font-family: Calibri; font-size: 16px;">
            </div>
            <div style="font-family: 'Arial'; font-size: 12px; width: 100%;">
                <div align="center" style="font-family: 'Arial'; font-size: 12px; width: 100%;">

                    <table align="center" width="100%" border="0" cellspacing="0" cellpadding="0" style="border-left: solid 1px #000; border-collapse: collapse; border-top: 1px solid #000; font-size: 14px;">

                        <tr>
                            <td width="90%" style="border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <h3 style="text-align: center; padding: 5px 10px; font-family: 'Arial'; margin: 0px; font-size: 15px;">SOLAR POWER PLANT PRAPOSAL : ROOF TOP‐ CAPTIVE‐ GRID CONNECTED</h3>
                            </td>
                            <td width="10%" style="vertical-align: top; border-top: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <h3 style="text-align: left; padding: 5px 10px; font-family: 'Arial'; margin: 0px; font-size: 15px;">C</h3>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <h3 style="text-align: center; padding: 5px 10px; font-family: 'Arial'; margin: 0px; font-size: 15px;">QUOTATION-Commercial</h3>
                            </td>

                        </tr>
                    </table>

                    <table align="center" width="100%" border="0" cellspacing="0" cellpadding="0" style="border-left: solid 1px #000; border-collapse: collapse; border-top: 1px solid #000; font-size: 14px;">
                        <tr>
                            <td width="20%" style="text-align: right; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Number : </strong>
                            </td>
                            <td width="40%" style="border-right: solid 1px #000; border-top: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: 'Arial'; font-size: 14px;">
                                <asp:Label ID="lblManualQuoteNumber" runat="server"></asp:Label>
                            </td>
                            <td width="40%" style="border-top: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: 'Arial'; font-size: 14px;">
                                <strong>Date: </strong>
                                <asp:Label ID="lblQuotationDate" runat="server"></asp:Label>
                            </td>


                        </tr>
                    </table>

                    <table align="center" width="100%" border="0" cellspacing="0" cellpadding="0" style="border-left: solid 1px #000; border-collapse: collapse; border-top: 1px solid #000; font-size: 14px;">
                        <tr>
                            <td width="30%" style="text-align: left; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Version : </strong>
                            </td>
                            <td width="70%" style="border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: 'Arial'; font-size: 14px;">
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </td>

                        </tr>
                    </table>

                    <table align="center" width="100%" border="0" cellspacing="0" cellpadding="0" style="border-left: solid 1px #000; border-collapse: collapse; border-top: 1px solid #000; font-size: 14px;">
                        <tr>
                            <td width="10%" style="text-align: left; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;"></td>
                            <td colspan="4" width="90%" style="border-right: solid 1px #000; border-bottom: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: 'Arial'; font-size: 14px;">
                                <strong>Customer:</strong>
                                <asp:Label ID="lblContFirst" runat="server"></asp:Label>
                                &nbsp;<asp:Label ID="lblContLast" runat="server"></asp:Label>
                                &nbsp;<asp:Label ID="lblInstallCity" runat="server"></asp:Label>
                            </td>
                        </tr>


                        <tr>
                            <td width="10%" style="text-align: left; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;"></td>
                            <td colspan="4" width="90%" style="border-right: solid 1px #000; border-bottom: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: 'Arial'; font-size: 14px;">
                                <strong>Reference:</strong>
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                                &nbsp;<asp:Label ID="Label3" runat="server"></asp:Label>
                                &nbsp;<asp:Label ID="Label4" runat="server"></asp:Label>
                            </td>
                        </tr>



                        <tr>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px; padding: 10px;">
                                <strong>Sr.no</strong>
                            </td>
                            <td width="50%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Description</strong>
                            </td>
                            <td width="20%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Installed Capacity (KW)</strong>
                            </td>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Rate/KW</strong>
                            </td>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Value (INR)</strong>
                            </td>
                        </tr>

                        <tr>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>1</strong>
                            </td>
                            <td width="50%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <p>Design,supply,erection and commissioning of roof-top grid tie solar PV power generation plant with standard lengths of cable. The solar power plant will consist of required no. of SPV panels, inverter and with all the electrical items suitable to the designed installed capacity</p>
                            </td>
                            <td width="20%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblInstalledCapacity" runat="server"></asp:Label>
                            </td>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblRate" runat="server"></asp:Label>
                            </td>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblValue" runat="server"></asp:Label>
                            </td>
                        </tr>




                        <tr>
                            <td colspan="4" style="text-align: right; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px; padding: 2px;">
                                <strong>Total Value</strong>

                            </td>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblTotalValue" runat="server"></asp:Label>
                            </td>
                        </tr>





                        <tr>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>2</strong>
                            </td>
                            <td width="50%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Roof top area @10 Sq.Mtr./KWp to be provided
                            </td>
                            <td colspan="3" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Customer Scope
                            </td>
                        </tr>

                        <tr>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>3</strong>
                            </td>
                            <td width="50%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Central/State Government available subsidy
                            </td>
                            <td colspan="3" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">NA
                            </td>
                        </tr>


                        <tr>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>4</strong>
                            </td>
                            <td width="50%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Civil Works
                            </td>
                            <td colspan="3" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Included
                            </td>
                        </tr>


                        <tr>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>5</strong>
                            </td>
                            <td width="50%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Module Mount Structure
                            </td>
                            <td colspan="3" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Included
                            </td>
                        </tr>

                        <tr>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>6</strong>
                            </td>
                            <td width="50%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Mounting,Erection and Commissioning
                            </td>
                            <td colspan="3" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Included
                            </td>
                        </tr>

                        <tr>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>7</strong>
                            </td>
                            <td width="50%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Power evacuations (solar plant to mains)
                            </td>
                            <td colspan="3" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Included
                            </td>
                        </tr>




                        <tr>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>8</strong>
                            </td>
                            <td width="50%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Lighting Arrester
                            </td>
                            <td colspan="3" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;"></td>
                        </tr>

                        <tr>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>9</strong>
                            </td>
                            <td width="50%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Earthing systems
                            </td>
                            <td colspan="3" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;"></td>
                        </tr>

                        <tr>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>10</strong>
                            </td>
                            <td width="50%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>GEDA registration, DISCOM and Net meter Charges</strong>
                            </td>
                            <td colspan="3" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Extra on actual basis</strong>
                            </td>
                        </tr>

                        <tr>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>11</strong>
                            </td>
                            <td width="50%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Free Operation & Maintenance</strong>
                            </td>
                            <td colspan="3" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Included for 1st Year</strong>
                            </td>
                        </tr>




                        <tr>
                            <td colspan="5" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Terms & Conditions</strong>
                            </td>
                        </tr>

                        <tr>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Sr.no</strong>
                            </td>
                            <td width="50%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Parameters</strong>
                            </td>
                            <td colspan="3" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Remarks</strong>
                            </td>
                        </tr>

                        <tr>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>1</strong>
                            </td>
                            <td width="50%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">All taxes, Duties, Levis,Cess etc.
                            </td>
                            <td colspan="3" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Extra at Actual                                
                            </td>
                        </tr>

                        <tr>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>2</strong>
                            </td>
                            <td width="50%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Transport charges, insurance charges
                            </td>
                            <td colspan="3" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Extra at Actual
                            </td>
                        </tr>




                        <tr>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>3</strong>
                            </td>
                            <td width="50%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Transport charges, insurance charges
                            </td>
                            <td colspan="3" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <ul>
                                    <li>5% Advance against signed PO</li>
                                    <li>65% Before dispatch of materials</li>
                                    <li>20% on starting of installation</li>
                                    <li>10% on installation but With PDC</li>
                                </ul>
                            </td>
                        </tr>





                        <tr>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>4</strong>
                            </td>
                            <td width="50%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Supply,Erection & Commissioning Period
                            </td>
                            <td colspan="3" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">As per Annexure Attached
                            </td>
                        </tr>

                        <tr>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>5</strong>
                            </td>
                            <td width="50%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Validity period for this quote
                            </td>
                            <td colspan="3" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">30 day from the date of this offer
                            </td>
                        </tr>

                        <tr>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>6</strong>
                            </td>
                            <td width="50%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">All extra and additional material/work
                            </td>
                            <td colspan="3" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">As per the bill raised on actual expenditure
                            </td>
                        </tr>

                        <tr>
                            <td colspan="5" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Warrantee</strong>
                            </td>
                        </tr>

                        <tr>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>1</strong>
                            </td>
                            <td width="50%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">SPV modules (for Manufacturing Defects)
                            </td>
                            <td colspan="3" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">10 Years
                            </td>
                        </tr>

                        <tr>
                            <td rawspan="3" width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>2</strong>
                            </td>
                            <td rawspan="3" width="50%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">SPV modules (for performance)
                            </td>
                            <td colspan="3" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">25 Years for performance
                                <br />
                                90% Power output for the 1st 10 year 
                                <br />
                                80% power output for the 2nd 15 Years
                            </td>
                        </tr>

                        <tr>
                            <td width="10%" style="text-align: center; border-right: solid 1px #000; border-bottom: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>3</strong>
                            </td>
                            <td width="50%" style="text-align: justify; border-right: solid 1px #000; border-bottom: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Inverter(for Manufacturing Defects)
                            </td>
                            <td colspan="3" style="text-align: center; border-right: solid 1px #000; border-bottom: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">5 Years free
                            </td>
                        </tr>

                    </table>

                    <table align="center" width="100%" border="0" cellspacing="0" cellpadding="0" style="border-left: solid 1px #000; border-collapse: collapse; font-size: 14px;">
                        <tr>
                            <td colspan="6" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Saving in Electricity Bill*(1)</strong>
                            </td>
                        </tr>


                        <tr>
                            <td width="20%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px; padding: 10px;">
                                <strong>Savings/Year</strong>
                            </td>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Plant Capacity (A)</strong>
                            </td>
                            <td width="20%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Unit Generation/kW/year (B)</strong>
                            </td>
                            <td width="20%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Total Generation/year (C = A x B)</strong>
                            </td>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Unit Rate (D)</strong>
                            </td>
                            <td width="20%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Total Saving (C x D)</strong>
                            </td>
                        </tr>


                        <tr>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">1st Year saving
                               
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblPlantCapacityFirstYear" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblUnitGenerationFirstYear" runat="server">1500</asp:Label>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblTotalGenerationFirstYear" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblUnitRateFY" runat="server">8</asp:Label>
                            </td>

                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblTotalSavingFirstYear" runat="server"></asp:Label>
                            </td>
                        </tr>



                        <tr>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">2nd Year Saving
                               
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblPlantCapacitySecondYear" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblUnitGenerationSecondYear" runat="server">1490</asp:Label>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblTotalGenerationSecondYear" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblUnitRateSY" runat="server">8</asp:Label>
                            </td>

                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblTotalSavingSecondYear" runat="server"></asp:Label>
                            </td>
                        </tr>


                        <tr>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">3rd Year Saving
                               
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblPlantCapacityThiredYear" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblUnitGenerationThiredYear" runat="server">1479</asp:Label>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblTotalGenerationThiredYear" runat="server"></asp:Label>
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblUnitRateTY" runat="server">8</asp:Label>
                            </td>

                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblTotalSavingThiredYear" runat="server"></asp:Label>
                            </td>
                        </tr>

                        <tr>
                            <td colspan="4" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;"></td>

                            <td width="20%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Total Savings of 3 year</strong>
                            </td>

                            <td width="60%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="lblTotalSaving" runat="server"></asp:Label>
                            </td>
                        </tr>

                    </table>

                    <div style="clear: both; page-break-before: always;"></div>
                    <table align="center" width="100%" border="0" cellspacing="0" cellpadding="0" style="border-left: solid 1px #000; border-collapse: collapse; font-size: 14px;">
                        <tr>
                            <td>
                                <table align="center" width="100%" border="0" cellspacing="0" cellpadding="0" style="border-left: solid 1px #000; border-collapse: collapse; border-top: 1px solid #000; font-size: 14px;">
                                    <tr>
                                        <td colspan="6" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>ITEMS CONSIDERED FOR PROPOSAL</strong>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px; padding: 10px;">
                                            <strong>Sr.no</strong>
                                        </td>
                                        <td width="35%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>Description</strong>
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>Unit</strong>
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>Qty.</strong>
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>Size</strong>
                                        </td>
                                        <td width="25%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>Make</strong>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>1</strong>
                                        </td>
                                        <td width="35%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Solar Modules
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Nos
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">As per design
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">As per design
                                        </td>

                                        <td width="25%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">U R Energy/Reputed
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>2</strong>
                                        </td>
                                        <td width="35%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Module mounting structure
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Set
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">As per design
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <asp:Label ID="Label30" runat="server"></asp:Label>
                                        </td>

                                        <td width="25%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Hot dip G.I/Aluminium
                                        </td>
                                    </tr>


                                    <tr>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>3</strong>
                                        </td>
                                        <td width="35%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">String type Grid Tied Inverter
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Nos
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">As per design
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">As per design
                                        </td>

                                        <td width="25%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">U R Energy/Reputed
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>4</strong>
                                        </td>
                                        <td width="35%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">AJB with accessories
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Nos
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">As per design
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <asp:Label ID="Label40" runat="server"></asp:Label>
                                        </td>

                                        <td width="25%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Standard
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>5</strong>
                                        </td>
                                        <td width="35%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">ACDB
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Nos
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">At actual
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">As per design
                                        </td>

                                        <td width="25%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Standard
                                        </td>
                                    </tr>


                                    <tr>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>6</strong>
                                        </td>
                                        <td width="35%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">DC cable with UV protected
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Mtr.
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">At actual
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">As per design
                                        </td>

                                        <td width="25%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Polycab/Reputed
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>7</strong>
                                        </td>
                                        <td width="35%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">AC Cable
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Mtr.
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">At actual
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">As per design
                                        </td>

                                        <td width="25%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Polycab/Reputed
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>8</strong>
                                        </td>
                                        <td width="35%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Earthing systems
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Nos
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">As per design
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">As per design
                                        </td>

                                        <td width="25%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Standard
                                        </td>
                                    </tr>


                                    <tr>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>9</strong>
                                        </td>
                                        <td width="35%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Lightening arrester systems
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Nos
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">NA
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">-
                                        </td>

                                        <td width="25%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">-
                                        </td>
                                    </tr>

                                    <tr>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>10</strong>
                                        </td>
                                        <td width="35%" style="text-align: justify; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">BOS
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Lot
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">At actual
                                        </td>
                                        <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <asp:Label ID="Label70" runat="server"></asp:Label>
                                        </td>

                                        <td width="25%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Standard
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="margin-top: 0px;" rowspan="2">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-left: solid 1px #000; border-collapse: collapse; border-top: 1px solid #000; font-size: 14px; margin-top: 0px;">
                                    <tr>
                                        <td colspan="2" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>Company Bank details</strong>
                                        </td>
                                    </tr>


                                    <tr>
                                        <td width="20%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>Account Name</strong>
                                        </td>
                                        <td width="35%" style="text-align: left; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">U R Energy India Pvt Ltd
                                        </td>

                                    </tr>

                                    <tr>
                                        <td width="20%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>Account Number</strong>
                                        </td>
                                        <td width="35%" style="text-align: left; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">50200009010883
                                        </td>

                                    </tr>

                                    <tr>
                                        <td width="20%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>Bank</strong>
                                        </td>
                                        <td width="35%" style="text-align: left; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">HDFC
                                        </td>

                                    </tr>

                                    <tr>
                                        <td width="20%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>Branch</strong>
                                        </td>
                                        <td width="35%" style="text-align: left; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Science City Road, Ahmedabad
                                        </td>

                                    </tr>

                                    <tr>
                                        <td width="20%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                            <strong>IFSC</strong>
                                        </td>
                                        <td width="35%" style="text-align: left; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">HDFC0003768
                                        </td>

                                    </tr>

                                </table>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-left: solid 1px #000; border-collapse: collapse; font-size: 14px; margin-top: 0px;">


                                    <tr>
                                        <td width="20%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-top: 1px solid #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;" class="auto-style1">
                                            <strong>Payment Terms:</strong>
                                        </td>
                                        <td width="35%" style="text-align: left; border-bottom: solid 1px #000; border-right: solid 1px #000; border-top: 1px solid #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;" class="auto-style1">

                                            <ul>
                                                <li>10% Advance along with order</li>
                                                <li>10% against finalization of drawings and design</li>
                                                <li>50% Performa invoice before dispatching modules.</li>
                                            </ul>

                                        </td>

                                    </tr>
                                    <tr>
                                        <td style="height:130px;"></td>
                                    </tr>

                                </table>
                            </td>
                           
                        </tr>
                    </table>






                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-left: solid 1px #000; border-collapse: collapse; border-top: 1px solid #000; font-size: 14px; margin-top: 20px;">
                        <tr>
                            <td colspan="2" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <strong>Estimated Other Charges</strong>
                            </td>

                        </tr>


                        <tr>
                            <td width="20%" style="text-align: left; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 12px;">Geda Registration

                            </td>
                            <td width="10%" style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 12px;">
                                <strong>11,500</strong>
                            </td>
                        </tr>


                        <tr>
                            <td style="text-align: left; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 12px;">DISCOM Conectivity Charges

                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 12px;">
                                <strong>Extra</strong>
                            </td>


                        </tr>

                        <tr>
                            <td style="text-align: left; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 12px;">Meter Charges

                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 12px;">
                                <strong>Extra</strong>
                            </td>

                        </tr>

                        <tr>
                            <td style="text-align: left; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 12px;">As per Government norms

                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 12px;">
                                <strong></strong>
                            </td>

                        </tr>
                    </table>

                    <table align="left" width="30%" border="0" cellspacing="0" cellpadding="0" style="border-left: solid 1px #000; border-collapse: collapse; border-top: 1px solid #000; font-size: 14px; margin-top: 20px;">
                        <tr>
                            <td style="text-align: left; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">For, E Solar CRM

                            </td>

                        </tr>


                        <tr>
                            <td style="text-align: left; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">E Solar (INDIA)
                            </td>

                        </tr>
                        <tr>
                            <td style="text-align: left; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">
                                <asp:Label ID="Label84" runat="server">For future queries please contact:</asp:Label>
                            </td>

                        </tr>

                        <tr>
                            <td style="text-align: left; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Name :-
                                <asp:Label ID="lblEmpFullName" runat="server"></asp:Label>

                            </td>

                        </tr>
                        <tr>
                            <td style="text-align: left; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Email :-
                                <asp:Label ID="lblEmail" runat="server"></asp:Label>

                            </td>

                        </tr>

                        <tr>
                            <td style="text-align: left; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Moile :- 
                                 <asp:Label ID="lblMobile" runat="server"></asp:Label>

                            </td>

                        </tr>

                    </table>

                    <table align="right" width="35%" border="0" cellspacing="0" cellpadding="0" style="border-left: solid 1px #000; border-collapse: collapse; border-top: 1px solid #000; font-size: 14px; margin-top: 20px;">

                        <tr>
                            <td style="text-align: left; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">Above offer is accepted and confirm
                            </td>
                        </tr>


                        <tr>
                            <td style="text-align: left; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">&nbsp;</td>
                        </tr>

                        <tr>
                            <td style="text-align: left; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">&nbsp;</td>
                        </tr>

                        <tr>
                            <td style="text-align: left; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">&nbsp;</td>
                        </tr>

                        <tr>
                            <td style="text-align: left; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">&nbsp;</td>
                        </tr>

                        <tr>
                            <td style="text-align: left; border-right: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px;">&nbsp;</td>
                        </tr>

                        <tr>
                            <td style="text-align: center; border-right: solid 1px #000; border-collapse: collapse; padding-top: 10px; font-family: Arial; font-size: 14px;">Customer Name:(________________________)
                            </td>
                        </tr>

                        <tr>
                            <td style="text-align: center; border-bottom: solid 1px #000; border-right: solid 1px #000; border-collapse: collapse; padding-top: 5px; font-family: Arial; font-size: 14px;">(Sign and Stamp)
                            </td>
                        </tr>

                    </table>

                    <br />
                </div>
            </div>

            <div style="font-family: 'Arial'; font-size: 12px; width: 100%;">
                <div align="center" style="font-family: 'Arial'; font-size: 12px; width: 100%; margin-top: 20px;">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-left: solid 1px #000; border-collapse: collapse; border-top: 1px solid #000; font-size: 14px;">

                        <tr>
                            <td style="text-align: left; border: solid 1px #000; border-collapse: collapse; padding: 2px; font-family: Arial; font-size: 14px; margin-top: 20px;">
                                <asp:Label ID="Label91" runat="server">We received cheque in amount of _______________ Rs. With cheque number _______________ on _________________ dated.</asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>


            <%-- <div style="font-family: 'Arial'; font-size: 12px; width: 100%;">
                <div align="left" style="font-family: 'Arial'; font-size: 12px; width: 100%; margin-top: 20px;">
                    *(1) Savings are dependent on condition of weather and regular maintenance of plant.<br />
                    *(2) URE Reserve rights to change technical specifications according to condition and requirement of site.
                </div>
            </div>--%>


            <%--<div style="width: 100%;">
                <div style="width: 960px; margin: 0px auto;">
                    <div class="toparea" style="font-family: Arial, Helvetica, sans-serif;">
                        <div style="float: left; font-family: Arial, Helvetica, sans-serif; padding: 5px 110px 0px 10px;">
                            <img src="<%=MakeImageSrcData( Request.PhysicalApplicationPath+"/images/GEDA.png") %>"
                                width="124" height="100" />
                        </div>

                        <div style="float: left; font-family: Arial, Helvetica, sans-serif; padding: 5px 110px 0px 0px;">
                            <img src="<%=MakeImageSrcData( Request.PhysicalApplicationPath+"/images/MNRE.png") %>"
                                width="124" height="100" />
                        </div>


                        <div style="float: left; font-family: Arial, Helvetica, sans-serif; padding: 5px 110px 0px 0px;">
                            <img src="<%=MakeImageSrcData( Request.PhysicalApplicationPath+"/images/TUV.png") %>"
                                width="124" height="100" />
                        </div>

                        <div style="float: left; font-family: Arial, Helvetica, sans-serif; padding: 5px 110px 0px 0px;">
                            <img src="<%=MakeImageSrcData( Request.PhysicalApplicationPath+"/images/ISO.png") %>"
                                width="124" height="100" />
                        </div>
                    </div>
                    <div style="clear: both;">
                    </div>
                </div>
            </div>--%>
        </div>
    </div>

</body>

</html>
