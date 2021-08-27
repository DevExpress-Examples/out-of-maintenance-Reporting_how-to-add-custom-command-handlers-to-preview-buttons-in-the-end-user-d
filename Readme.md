<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128598336/10.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E98)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/dxKB13085/Form1.cs) (VB: [Form1.vb](./VB/dxKB13085/Form1.vb))
<!-- default file list end -->
# How to add custom command handlers to Preview buttons in the End-User Designer


<p>This example demonstrates how to perform custom actions when an end-user clicks on a toolbar button on the Preview tab of the End-User Designer. In this scenario, the standard approach (<a href="http://documentation.devexpress.com/#XtraReports/CustomDocument2620">How to: Override Commands in Preview (Custom Exporting)</a>) doesn't work, because when a report is previewed by an end-user in the End-User Report Designer, it's really cloned (first serialized and then de-serialized). However, as a workaround, you can add a custom script for a report's <strong>OnAfterPrint</strong> script, and add a command handler in it.</p>

<br/>


