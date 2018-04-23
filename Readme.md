# How to add custom command handlers to Preview buttons in the End-User Designer


<p>This example demonstrates how to perform custom actions when an end-user clicks on a toolbar button on the Preview tab of the End-User Designer. In this scenario, the standard approach (<a href="http://documentation.devexpress.com/#XtraReports/CustomDocument2620">How to: Override Commands in Preview (Custom Exporting)</a>) doesn't work, because when a report is previewed by an end-user in the End-User Report Designer, it's really cloned (first serialized and then de-serialized). However, as a workaround, you can add a custom script for a report's <strong>OnAfterPrint</strong> script, and add a command handler in it.</p>

<br/>


