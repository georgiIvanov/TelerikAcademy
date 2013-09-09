using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace _01.SearchControls
{
    public partial class CarSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (ViewState["producersLoaded"] == null)
            {
                this.producersList.DataSource = Initializer.Producers;
                this.producersList.DataBind();
                ViewState.Add("producersLoaded", true);

                ExtrasCheckBoxList.DataSource = Initializer.Extras;
                this.ExtrasCheckBoxList.DataBind();

                EngineTypesRadioList.DataSource = Initializer.EngineTypes;
                EngineTypesRadioList.DataBind();
            }
        }

        protected void producersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedProducer = (from n in Initializer.Producers
                                    where n.Name == this.producersList.SelectedValue
                                    select n)
                               .FirstOrDefault();
            if (selectedProducer != null)
            {
                modelsList.DataSource = selectedProducer.Models;
                modelsList.DataBind();
            }
            else
            {
                modelsList.DataSource = new string[] { };
                modelsList.DataBind();
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            var html = new HtmlGenericControl("div");
            var breakLine = "<br/>";
            html.InnerHtml += producersList.SelectedValue + breakLine;
            html.InnerHtml += modelsList.SelectedValue + breakLine;

            foreach (ListItem item in ExtrasCheckBoxList.Items)
            {
                if (item.Selected)
                {
                    html.InnerHtml += item + breakLine;
                }

            }

            html.InnerHtml += EngineTypesRadioList.SelectedValue + breakLine;

            ShowSubmitted.Text = html.InnerText;
        }
    }
}