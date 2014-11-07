using HtmlAgilityPack;
using mshtml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {


        if (RadioButtonList1.SelectedValue.ToString().Equals("OLX"))
        {
            Label1.Text = getResultsViaWebClient(searchOLX_URL(TextBox1.Text, DropDownList1.SelectedValue.ToString()));
        }
        else if (RadioButtonList1.SelectedValue.ToString().Equals("Hafeez Centre"))
        {
            Label1.Text = getResultsViaWebClient(searchHafeezCentre_URL(TextBox1.Text, DropDownList1.SelectedValue.ToString()));
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        var webGet = new HtmlWeb();
        string results = null;
       
        
        if (RadioButtonList1.SelectedValue.ToString().Equals("OLX")) {
        var document=webGet.Load(searchOLX_URL(TextBox1.Text,DropDownList1.SelectedValue.ToString()));
        results=document.GetElementbyId("offers_table").OuterHtml;
        Label1.Text=results;
        }

        else if (RadioButtonList1.SelectedValue.ToString().Equals("Hafeez Centre")) {
            var document = webGet.Load(searchHafeezCentre_URL(TextBox1.Text, DropDownList1.SelectedValue.ToString()));
            results = document.GetElementbyId("list_warper").OuterHtml;
            Label1.Text = results;
        
        }
     
    }
    public string getURL(string hostname) {
        string url = "";
        if (hostname.Equals("OLX")) {

            url = "http://olx.com.pk";
            if (DropDownList1.SelectedValue.ToString() != "Other")
            {
                url = url + "/" + DropDownList1.SelectedValue.ToString() + "/?q=" + TextBox1.Text;
            }
            else
            {
                url = url + "/all-results/?q=" + TextBox1.Text;
            }
            return url;
        }

        else if (hostname.Equals("Hafeez Centre")) {

            url = "http://www.hafeezcentre.pk/search";
            
            if (DropDownList1.SelectedValue.ToString() != "Other")
            {
                url = url + "/?mass_keyWord=" + TextBox1.Text + "&mas_city=" + DropDownList1.SelectedValue.ToString();
            }
            else
            {
                  url = url + "/?mass_keyWord=" + TextBox1.Text ;
            }
           
        
        }
        return url;
    }

    public string searchOLX_URL(string value,string city) {

      string  url = "http://olx.com.pk";
        if (DropDownList1.SelectedValue.ToString() != "Other")
        {
            url = url + "/" + city + "/?q=" + value;
        }
        else
        {
            url = url + "/all-results/?q=" + value;
        }

        return url;
    
    }

    public string searchHafeezCentre_URL(string value, string city) {

        string url = "http://www.hafeezcentre.pk/search";

        if (DropDownList1.SelectedValue.ToString() != "Other")
        {
            url = url + "/?mass_keyWord=" + value + "&mas_city=" + city;
        }
        else
        {
            url = url + "/?mass_keyWord=" + value;
        }
        return url;
    
    }


    public string getResultsViaWebClient(string url) {
        WebClient client = new WebClient();
        // Retrieve resource as a stream
        Stream data = client.OpenRead(new Uri(url));
        // Retrieve the text
        StreamReader reader = new StreamReader(data);
        string htmlContent = reader.ReadToEnd();

        // Cleanup
        data.Close();
        reader.Close();



        // Obtain the document interface
        IHTMLDocument2 htmlDocument = (IHTMLDocument2)new mshtml.HTMLDocument();

        // Construct the document
        htmlDocument.write(htmlContent);

        //  listBox1.Items.Clear();
        List<string> images = new List<string>();
        List<string> allElementsList = new List<string>();

        // Extract all elements
        IHTMLElementCollection allElements = htmlDocument.all;

        // Iterate all the elements and display tag names
        foreach (IHTMLElement element in allElements)
        {
            allElementsList.Add(element.tagName);
        }

        // Extract all image elements
        IHTMLElementCollection imgElements = htmlDocument.images;

        // Iterate through each image element
        foreach (IHTMLImgElement img in imgElements)
        {
            images.Add(img.src);
        }

        return htmlContent;
    }
}