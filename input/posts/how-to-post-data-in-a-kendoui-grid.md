﻿Title: How to Post Data (Including Checkboxes) in a KendoUI Grid back to an ASP.NET MVC Action
Published: 1/3/2014
Tags:
  - ASP.NET
  - ASP.NET MVC
  - KendoUI
  - KendoUI MVC
  - grid
  - checkbox
  - postback
---

<p>The KendoUI grid is great for displaying data and manipulating it one row at a time. There are several options available including posting the edited data back via AJAX, performing in-line editing, etc. However, there is no built-in support for posting the grid data on form submission because the grid isn't an actual form control. This came up recently when designing a feature for an enterprise contact list. I had a view that should allow the user to select two contacts and merge them into one. The user needed to be able to select which addresses, phone numbers, etc. from both contact should be kept in the merged contact. A grid seemed like a perfect interface match since it supports multiple columns and I could (presumably) add a checkbox to the first (or last) one for the user to select. This turned out to be much more complicated than I had anticipated and there isn't a lot of help out there, so I'll walk you through the process.</p>

<h1>The Model</h1>

<p>My model is simple:</p>

<pre class="prettyprint">public class ContactInfoGridItem
{
    public string ContactInfoId { get; set; }
    public bool Keep { get; set; }
    public string Contact { get; set; }
    public string Type { get; set; }
    public string Content { get; set; }
}</pre>

<p>The important fields are <code>ContactInfoId</code> and <code>Keep</code> – <code>Contact</code>, <code>Type</code>, and <code>Content</code> are just bits of domain data for display to the user but won't be posted back on submit (they'll get default values after model binding).</p>

<h1>The Action</h1>

<p>This is the action we eventually want to receive the data:</p>

<pre class="prettyprint">public virtual ActionResult Index(IEnumerable&lt;ContactInfoGridItem&gt; contactInfo)
{
    //...
}</pre>

<p>We want the grid to send us a collection of <code>ContactInfoGridItems</code>. In my collection I only need the <code>ContactInfoId</code> and <code>Keep</code> fields to be set.</p>

<h1>The View</h1>

<p>The grid is declared like this (using KendoUI for ASP.NET MVC):</p>

<pre class="prettyprint">@(Html.Kendo().Grid(new List&lt;ContactInfoGridItem&gt;())
    .Name("grid")
    .DataSource(d =&gt; d.Ajax()
        .Read(r =&gt; r.Action(MVC.ContactList.Merge.ContactInfoGridRead()))
        .ServerOperation(false))
    .Columns(c =&gt;
    {
        c.Bound(m =&gt; m.ContactInfoId).Hidden()
            .ClientTemplate("&lt;input type='hidden' "
                + "name='contactInfo[#= gridIndex(data) #].ContactInfoId' "
                + "value='#= ContactInfoId #' /&gt;");
        c.Bound(m =&gt; m.Keep)
            .ClientTemplate("&lt;input type='checkbox' "
                + "name='contactInfo[#= gridIndex(data) #].Keep' "
                + "value='true' "
                + "#if (Keep) { #checked='checked'# } #/&gt;"
                + "&lt;input type='hidden' value='false' "
                + "name='contactInfo[#= gridIndex(data) #].Keep' /&gt;");
        c.Bound(m =&gt; m.Contact);
        c.Bound(m =&gt; m.Type);
        c.Bound(m =&gt; m.Content);
    }))</pre>

<p>So what's going on here? Don't worry about the Action – if you've never seen this syntax before, I'm just using <a href="http://t4mvc.codeplex.com/">T4MVC</a> (which I love) to eliminate magic strings. The first important note is that I'm declaring <code>ServerOperation(false)</code> on the <code>DataSource</code>. This ensures that KendoUI properly sends the data back to the server. I found <a href="http://www.kendoui.com/code-library/mvc/grid/submit-form-containing-grid-along-with-other-input-elements.aspx">this example</a> very helpful in understanding how to rig up posting of grid data. Next, notice the client templates for the <code>ContactInfoId</code> and <code>Keep</code> columns. The general principle here is that if we stick form controls (even hidden ones) directly inside the grid then they will get posted to the server like any other form control. The trick to getting a grid to work though is knowing how to identify and name form controls in such a way that ASP.NET MVC understands how to turn them into a collection. This can be accomplished by adding brackets after the form control name with an index – see <a href="http://haacked.com/archive/2008/10/23/model-binding-to-a-list.aspx/">this blog post</a> for more details.</p>

<p>What I've covered so far works great for posting back form controls such as combo boxes and text entries as well as posting back hidden form controls with the initial data for a row and column. However, there is one more trick we need to use to get checkboxes to post successfully. The problem is that unlike other form controls, checkbox inputs do not post their data in the same way. Checking a checkbox does not actually change it's value. It took some digging to figure out how to get this to work, but I eventually stumbled upon <a href="http://stackoverflow.com/questions/14730746/getting-checkbox-value-in-asp-net-mvc-4">a very helpful Stack Overflow post</a>. It turns out that ASP.NET MVC and the default model binder use a little hack to get checkbox values bound on post. They create the checkbox with a value of true, but then also create a hidden input with the same name and a value of false. When a form is submitted, the model binder knows how to reconcile the two identically named form inputs to come up with the actual value of the checkbox based on it's checked state. We just need to use the same technique in our column client template and let the default model binder do it's thing.</p>

<p>Now when I post the form that contains this grid I'll get a collection of <code>ContactInfoGridItem</code> models with the correct <code>ContactInfoId</code> and <code>Keep</code> fields.</p>