namespace Infrastructure.Mailing;

public static class MailTemplate
{
  private static string _html = @"<html>
  <head>
    <style>
      body {
        font-family: Calibri, sans-serif;
        font-size: 16px;
        line-height: 1.5;
        background-color: #343443;
        display: flex;
        justify-content: center;
      }
      h2 {
        color: black;
text-align: center;
    font-size: 38px;
      }
p{
text-align: center;
    font-size: 28px;
}
      a {
        color: #337ab7;
        text-decoration: none;
      }
      a:hover {
        text-decoration: underline;
      }
      .container {
        max-width: 600px;
        margin: 0 auto;
        padding: 20px;
      }
      .header {
        background-color: #343443;
        padding: 15px;
        display: flex;
        align-items: center;
      }
      .header img {
            width: 73px;
    height: 66px;
    margin-left: 60px;
      }
      .header h1 {
        margin: 0;
        font-size: 22px;
        font-weight: normal;
        color: white;
        margin-left: auto;
        line-height: 73px;
        font-family: 'Google Sans';
        font-weight: 500;
margin-right: 73px;
      }
      .body {
        background-color: #fff;
        padding: 20px;
        font-family: 'Google Sans';
        font-size: medium;
      }
      .footer {
        background-color: #343443;
        padding: 10px;
        text-align: center;
      }
      .footer p {
        margin: 0;
        font-size: 14px;
        color: white;
        font-family: 'Google Sans';
      }
    </style>
  </head>
  <body>
    <div class=""container"">
            <div class=""header"">
            <img src=""https://imgur.com/aCvhaAs.png"" alt=""Company Logo"">
            <h1>Company X</h1>
            </div>
            <div class=""body"">
            <h2>YOUR PASSWORD IS</h2>
            <p><b>$$body</b></p>
            </div>
            <div class=""footer"">
            <p>SDE@Company X</p>
            </div>
            </div>
            </body>
            </html>
            ";

  public static string GetMailTemplate(string body)
  {
    return _html.Replace("$$body", body);
  }
}