using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text;

using YD.Compare;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string a = File.ReadAllText(MapPath("Diff.cs.v4"));
        string b = File.ReadAllText(MapPath("Diff.cs.v5"));

        Compare compare = new Compare(a, b);
        ResultLine[] result = compare.GetResult(false, false, false);

        Response.Write("<table cellpadding='0' cellspacing='0'>");
        foreach (ResultLine line in result)
        {
            //if (line.ResultState == CompareState.Different)
            //{
            //    responseDifferentLine(line);
            //    continue;
            //}

            Response.Write("<tr>");
            if (line.LineNumberA != -1)
                Response.Write("<td class='" + line.ResultState.ToString() + "'>" + line.LineNumberA.ToString() + "&nbsp;&nbsp;</td>");
            else
                Response.Write("<td class='" + line.ResultState.ToString() + "'>&nbsp;</td>");

            Response.Write("<td class='" + line.ResultState.ToString() + "'>" + line.LineContentA.ToString().Replace(" ", "&nbsp;") + "</td>");

            if (line.LineNumberB != -1)
                Response.Write("<td class='" + line.ResultState.ToString() + "'>" + line.LineNumberB.ToString() + "&nbsp;&nbsp;</td>");
            else
                Response.Write("<td class='" + line.ResultState.ToString() + "'>&nbsp;</td>");

            Response.Write("<td class='" + line.ResultState.ToString() + "'>" + line.LineContentB.ToString().Replace(" ", "&nbsp;") + "</td>");
            Response.Write("</tr>");
        }
        Response.Write("</table>");
    }

    private void responseDifferentLine(ResultLine oline)
    {
        Compare compare = new Compare(changeStringToLines(oline.LineContentA), changeStringToLines(oline.LineContentB));
        ResultLine[] result = compare.GetResult(false, false, false);

        StringBuilder aContentBuilder = new StringBuilder();
        StringBuilder bContentBuilder = new StringBuilder();

        CompareState state = result[0].ResultState;
        aContentBuilder.AppendFormat("<span class ='{0}'>", state);
        bContentBuilder.AppendFormat("<span class ='{0}'>", state);

        foreach (ResultLine line in result)
        {
            if (line.ResultState == state)
            {
                aContentBuilder.Append("&nbsp" + line.LineContentA.Replace(" ", "&nbsp;"));
                bContentBuilder.Append("&nbsp" + line.LineContentB.Replace(" ", "&nbsp;"));
            }
            else
            {
                state = line.ResultState;
                aContentBuilder.AppendFormat("</span><span class ='{0}'>", state);
                aContentBuilder.Append("&nbsp" + line.LineContentA.Replace(" ", "&nbsp;"));
                bContentBuilder.AppendFormat("</span><span class ='{0}'>", state);
                bContentBuilder.Append("&nbsp" + line.LineContentB.Replace(" ", "&nbsp;"));
            }
        }
        aContentBuilder.Append("</span>");
        bContentBuilder.Append("</span>");

        Response.Write("<tr>");
        Response.Write("<td class='" + oline.ResultState.ToString() + "'>" + oline.LineNumberA.ToString() + "&nbsp;&nbsp;</td>");
        Response.Write("<td class='" + oline.ResultState.ToString() + "'>" + aContentBuilder.ToString() + "</td>");
        Response.Write("<td class='" + oline.ResultState.ToString() + "'>" + oline.LineNumberB.ToString() + "&nbsp;&nbsp;</td>");
        Response.Write("<td class='" + oline.ResultState.ToString() + "'>" + bContentBuilder.ToString() + "</td>");
        Response.Write("</tr>");

    }
    private string changeStringToLines(string oString)
    {
        return oString.Replace(" ", "\n");
    }
}
