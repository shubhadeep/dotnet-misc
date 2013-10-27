//-----------------------------------------------------------------------
// <summary>
// Code behind for default test page.
// </summary>
// <copyright file="Default.aspx.cs" company="Shubhadeep Dhar">
//     Copyright (c) Shubhadeep Dhar. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace UltraWebGridPatch
{
    using System;
    using System.Web;
    using System.Web.UI;

    public partial class Default : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.DebugMessage("Page Load");
            
            HttpRequest request = Context.Request;
            
            this.lblBrowserCapabilities.Text = this.GetBrowserCapabilities(Context.Request);
        }
        
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            
            if (!Page.IsPostBack)
            {
                bool ultraWebGridPatchStatus = UltraWebGridPatcher.PatchUltraWebGrid(this.Page);
            
                this.DebugMessage("UpgraWebGrid Patch Status: " + ultraWebGridPatchStatus.ToString());
            }
        }
        
        protected void GridOnDblClick(object sender, EventArgs e)
        {
            this.EventAlert("OnDblClick");
        }
        
        protected void EventAlert(string message)
        {
            this.DebugMessage(message + " event was fired");
        }
        
        protected void DebugMessage(string message)
        {
            this.lbl1.Text += "[" + message + "]<br/>";
        }
    
        private string GetBrowserCapabilities(HttpRequest request)
        {
            System.Web.HttpBrowserCapabilities browser = request.Browser;
            string s = "<strong>Browser Capabilities</strong><br/>"
                + "Type = "                    + browser.Type + "<br/>"
                + "Name = "                    + browser.Browser + "<br/>"
                + "Version = "                 + browser.Version + "<br/>"
                + "Major Version = "           + browser.MajorVersion + "<br/>"
                + "Minor Version = "           + browser.MinorVersion + "<br/>"
                + "Platform = "                + browser.Platform + "<br/>"
                + "Is Beta = "                 + browser.Beta + "<br/>"
                + "Is Crawler = "              + browser.Crawler + "<br/>"
                + "Is AOL = "                  + browser.AOL + "<br/>"
                + "Is Win16 = "                + browser.Win16 + "<br/>"
                + "Is Win32 = "                + browser.Win32 + "<br/>"
                + "Supports Frames = "         + browser.Frames + "<br/>"
                + "Supports Tables = "         + browser.Tables + "<br/>"
                + "Supports Cookies = "        + browser.Cookies + "<br/>"
                + "Supports VBScript = "       + browser.VBScript + "<br/>"
                + "Supports JavaScript = "     + 
                    browser.EcmaScriptVersion.ToString() + "<br/>"
                + "Supports Java Applets = "   + browser.JavaApplets + "<br/>"
                + "Supports ActiveX Controls = " + browser.ActiveXControls 
                      + "<br/>"
                + "Supports JavaScript Version = " +
                    browser["JavaScriptVersion"] + "<br/>";
    
            return s;
        }
    }
}