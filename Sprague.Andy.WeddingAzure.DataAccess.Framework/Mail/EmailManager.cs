using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using Sprague.Andy.WeddingAzure.Models.Rsvp;

namespace Sprague.Andy.WeddingAzure.DataAccess.Mail
{
    public class EmailManager
    {
        private readonly SmtpClient _client;

        public EmailManager(ServiceConfiguration config)
        {
            _client = new SmtpClient
            {
                Host = "Smtp.Gmail.com",
                Port = 587,
                EnableSsl = true,
                Timeout = 10000,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("landoweddingreservations@gmail.com", "!I?E)wGpY3FLHLK=lN")
            };
        }

        public void SendRsvpRecieved(RsvpEntity rsvpEntity)
        {
            var attendingWeddingText = rsvpEntity.AttendingWedding ? "YES" : "NO";
            var attendingPopInTheParkText = rsvpEntity.AttendingPopInThePark ? "YES" : "NO";

            var bodyString = new StringBuilder();
            bodyString.AppendLine($"<p>New RSVP recieved from {rsvpEntity.Name}!</p>");
            bodyString.AppendLine("<p></p>");
            bodyString.AppendLine("<ul>");
            bodyString.AppendLine($"<li>Attending Wedding: {attendingWeddingText}</li>");
            bodyString.AppendLine($"<li>Attending Pop In The Park: {attendingPopInTheParkText}</li>");
            bodyString.AppendLine($"<li>Dietary Requirements: {rsvpEntity.DietaryRequirements ?? "None"}</li>");
            bodyString.AppendLine($"<li>Song Request: {rsvpEntity.SongRequest ?? "None"}</li>");
            bodyString.AppendLine("</ul>");
            bodyString.AppendLine("</ul>");
            bodyString.AppendLine("<p>And here is a random cat pic:</p>");
            bodyString.AppendLine("<a href='http://thecatapi.com'><img src='http://thecatapi.com/api/images/get?format=src&type=gif'></a>");
            var body = bodyString.ToString();

            var msg = new MailMessage
            {
                From = new MailAddress("landoweddingreservations@Gmail.com", "landoweddingreservations"),
                To = {"landyshared@gmail.com"},
                Subject = "RSVP Recieved!",
                IsBodyHtml = true,
                Body = body,
                BodyEncoding = Encoding.UTF8
            };

            try
            {
                _client.Send(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
                throw;
            }
        }
    }
}