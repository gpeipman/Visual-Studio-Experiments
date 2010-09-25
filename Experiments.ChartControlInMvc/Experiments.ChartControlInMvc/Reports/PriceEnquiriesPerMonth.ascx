<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PriceEnquiriesPerMonth.ascx.cs" Inherits="Experiments.ChartControlInMvc.Reports.PriceEnquiriesPerMonth" %>
<%@ Register 
    assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    namespace="System.Web.UI.DataVisualization.Charting"
    tagprefix="asp" 
%>
 
<asp:Chart ID="Chart1" runat="server" Palette="Excel"
    Height="200px" Width="200px">
    <series>
        <asp:Series Name="Series2"
            CustomProperties="DrawingStyle=Emboss"
            XValueMember="Date" 
            YValueMembers="Count" 
            IsValueShownAsLabel="True"
            Font="Microsoft Sans Serif, 8pt" 
            LabelBackColor="255, 255, 192"
            LabelBorderColor="192, 192, 0" 
            LabelForeColor="Red">          
        </asp:Series>
    </series>
    <chartareas>
        <asp:ChartArea Name="ChartArea1" BorderDashStyle="Solid">
            <AxisX 
                IntervalAutoMode="VariableCount" 
                IntervalOffsetType="Days"
                IntervalType="Days" 
                IsLabelAutoFit="False" 
                IsStartedFromZero="False">
                <MajorGrid  
                    Interval="Auto" 
                    IntervalOffsetType="Days" 
                    IntervalType="Days" />
            </AxisX>
        </asp:ChartArea>
    </chartareas>
    <Titles>
        <asp:Title  
            Font="Microsoft Sans Serif, 8pt, style=Bold"
            Name="Title1"
            Text="Last 3 months enquiries">
        </asp:Title>
    </Titles>
</asp:Chart>