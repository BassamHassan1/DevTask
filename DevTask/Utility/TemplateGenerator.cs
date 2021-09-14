using System.Text;

namespace DevTask.Utility
{
    public static class TemplateGenerator
    {
        public static string GetHTMLString()
        {
            var customers = DataStoage.GetAllCustomers();

            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is the generated PDF report!!!</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Name</th>
                                        <th>LastName</th>
                                        <th>Age</th>
                                        <th>Gender</th>
                                    </tr>");

            foreach (var cust in customers)
            {
                sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", cust.CustomerFirstName, cust.CustomerLastName, cust.CustomerGender, cust.CustomerEmail);
            }

            sb.Append(@"
                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }
    }
}