<%@ Page 
    Title="UltraWebGrid Test" 
    Language="C#" 
    AutoEventWireup="false" 
    CodeBehind="Default.aspx.cs"
    Inherits="UltraWebGridPatch.Default" %><html>
  <head runat="server">
    <style>#lbl1 {color: red; background-color: yellow;}</style>
  </head>
  <body>
    <form runat="server">
      <igtbl:UltraWebGrid 
       ID="UltraWebGrid1" 
       runat="server"
       OnDblClick="GridOnDblClick">
        <Rows>
          <igtbl:UltraGridRow Height="">
            <Cells>
              <igtbl:UltraGridCell Text="Ram"></igtbl:UltraGridCell>
              <igtbl:UltraGridCell Text="Delhi"></igtbl:UltraGridCell>
              <igtbl:UltraGridCell Text="India"></igtbl:UltraGridCell>
              <igtbl:UltraGridCell Text="9999999999"></igtbl:UltraGridCell>
            </Cells>
          </igtbl:UltraGridRow>
          <igtbl:UltraGridRow Height="">
            <Cells>
              <igtbl:UltraGridCell Text="Sita"></igtbl:UltraGridCell>
              <igtbl:UltraGridCell Text="Kolkata"></igtbl:UltraGridCell>
              <igtbl:UltraGridCell Text="India"></igtbl:UltraGridCell>
              <igtbl:UltraGridCell Text="8888888888"></igtbl:UltraGridCell>
            </Cells>
          </igtbl:UltraGridRow>
          <igtbl:UltraGridRow Height="">
            <Cells>
              <igtbl:UltraGridCell Text="Laxman"></igtbl:UltraGridCell>
              <igtbl:UltraGridCell Text="Mumbai"></igtbl:UltraGridCell>
              <igtbl:UltraGridCell Text="India"></igtbl:UltraGridCell>
              <igtbl:UltraGridCell Text="7777777777"></igtbl:UltraGridCell>
            </Cells>
          </igtbl:UltraGridRow>
        </Rows>
        <Bands>
          <igtbl:UltraGridBand>
            <Columns>
              <igtbl:UltraGridColumn HeaderText="Name" BaseColumnName="">
                <Header Caption="Name"></Header>
              </igtbl:UltraGridColumn>
              <igtbl:UltraGridColumn HeaderText="City" BaseColumnName="">
                <Header Caption="City"></Header>
              </igtbl:UltraGridColumn>
              <igtbl:UltraGridColumn HeaderText="Country" BaseColumnName="">
                <Header Caption="Country"></Header>
              </igtbl:UltraGridColumn>
              <igtbl:UltraGridColumn HeaderText="Phone" BaseColumnName="">
                <Header Caption="Phone"></Header>
              </igtbl:UltraGridColumn>
            </Columns>
           </igtbl:UltraGridBand>
           </Bands>
      </igtbl:ultrawebgrid>
      <hr/>
      <asp:Label id="lbl1" runat="server"></asp:Label>
      <hr/>
      <asp:Label id="lblBrowserCapabilities" runat="server"></asp:Label>
    </form>
  </body>
</html>