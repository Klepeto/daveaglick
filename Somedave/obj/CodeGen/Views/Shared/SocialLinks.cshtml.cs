#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Somedave.Views.Shared
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    using FluentBootstrap;
    using Somedave;
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Shared/SocialLinks.cshtml")]
    public partial class SocialLinks : Somedave.SomedaveViewPage<dynamic>
    {
        public SocialLinks()
        {
        }
        public override void Execute()
        {
            
            #line 1 "..\..\Views\Shared\SocialLinks.cshtml"
 using (var list = Bootstrap.List())
{
    
            
            #line default
            #line hidden
            
            #line 3 "..\..\Views\Shared\SocialLinks.cshtml"
Write(list.ListItem(Bootstrap.Link(" Twitter (somedaveg)", "https://twitter.com/somedaveg").AddCss("icon-twitter")));

            
            #line default
            #line hidden
            
            #line 3 "..\..\Views\Shared\SocialLinks.cshtml"
                                                                                                                  
    
            
            #line default
            #line hidden
            
            #line 4 "..\..\Views\Shared\SocialLinks.cshtml"
Write(list.ListItem(Bootstrap.Link(" GitHub (somedave)", "https://github.com/somedave").AddCss("icon-github-square")));

            
            #line default
            #line hidden
            
            #line 4 "..\..\Views\Shared\SocialLinks.cshtml"
                                                                                                                    
    
            
            #line default
            #line hidden
            
            #line 5 "..\..\Views\Shared\SocialLinks.cshtml"
Write(list.ListItem(Bootstrap.Link(" Stack Overflow (somedave)", "http://stackoverflow.com/users/807064/somedave").AddCss("icon-stackoverflow")));

            
            #line default
            #line hidden
            
            #line 5 "..\..\Views\Shared\SocialLinks.cshtml"
                                                                                                                                               
    
            
            #line default
            #line hidden
            
            #line 6 "..\..\Views\Shared\SocialLinks.cshtml"
Write(list.ListItem(Bootstrap.Link(" LinkedIn", "http://www.linkedin.com/pub/dave-glick/a/871/424/").AddCss("icon-linkedin-square")));

            
            #line default
            #line hidden
            
            #line 6 "..\..\Views\Shared\SocialLinks.cshtml"
                                                                                                                                   
    
            
            #line default
            #line hidden
            
            #line 7 "..\..\Views\Shared\SocialLinks.cshtml"
Write(list.ListItem(Bootstrap.Link(" Flickr (somedave)", "http://flickr.com/photos/somedave/").AddCss("icon-flickr-1")));

            
            #line default
            #line hidden
            
            #line 7 "..\..\Views\Shared\SocialLinks.cshtml"
                                                                                                                      
    
            
            #line default
            #line hidden
            
            #line 8 "..\..\Views\Shared\SocialLinks.cshtml"
Write(list.ListItem(Bootstrap.Link(" Goodreads (somedave)", "http://www.goodreads.com/somedave").AddCss("icon-goodreads")));

            
            #line default
            #line hidden
            
            #line 8 "..\..\Views\Shared\SocialLinks.cshtml"
                                                                                                                         
}

            
            #line default
            #line hidden
        }
    }
}
#pragma warning restore 1591