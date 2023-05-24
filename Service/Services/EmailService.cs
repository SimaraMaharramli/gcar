using Domain.Entities;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using MimeKit;
using MimeKit.Text;
using Service.Services.DTOs.Account;
using ServiceLayer.DTOs.AppUser;
using ServiceLayer.Services.Interfaces;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Service.Services
{
    public class EmailService : IEmailService
    {
        private readonly UserManager<AppUser> _userManager;
        //private readonly IWebHostEnvironment _env;
        private readonly IHttpContextAccessor _accessor;
        private readonly LinkGenerator _generator;

        public EmailService(UserManager<AppUser> userManager, LinkGenerator generator, IHttpContextAccessor accessor)
        {
            _userManager = userManager;
            _generator = generator;
            _accessor = accessor;

        }


        public void Register(RegisterDto registerDto, string link)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("GolfCar", "customar.test.golfcar@gmail.com"));
            message.To.Add(new MailboxAddress(registerDto.Fullname, registerDto.Email));
            message.Subject = "Confirm Email";
            string emailbody = string.Empty;

            //using (StreamReader streamReader = new StreamReader(Path.Combine(_env.WebRootPath, "Templates", "Confirm.html")))
            //{
            //    emailbody = streamReader.ReadToEnd();
            //}

            emailbody = emailbody.Replace("{{code}}", $"{link}").Replace("{{fullname}}", $"{registerDto.Fullname}");
            message.Body = new TextPart(TextFormat.Html) { Text = emailbody };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("customar.test.golfcar@gmail.com", "psutapkrmjbciuct");
            smtp.Send(message);
            smtp.Disconnect(true);
        }




        public async Task ConfirmEmail(string userId, string token)
        {

            AppUser user = await _userManager.FindByIdAsync(userId);

            await _userManager.ConfirmEmailAsync(user, token);
        }

        public void OrderCreate(string email, string eventname, string seat, string hallname, string date)
        {

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("GolfCar", "customar.test.golfcar@gmail.com"));

            message.To.Add(new MailboxAddress("", email));

            message.Subject = "Bizi Seçdiyiniz Üçün Təşəkkürlər";
            string emailbody = string.Empty;
            //using (StreamReader streamReader = new StreamReader(Path.Combine(_env.WebRootPath, "Templates", "Order.html")))
            //{
            //    emailbody = streamReader.ReadToEnd();
            //}


            emailbody = emailbody.Replace("{{eventname}}", $"{eventname}").Replace("{{seatid}}", $"{seat}").Replace("{{hallname}}", $"{hallname}").Replace("{{date}}", $"{date}");
            message.Body = new TextPart(TextFormat.Html) { Text = emailbody };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("customar.test.golfcar@gmail.com", "psutapkrmjbciuct");
            smtp.Send(message);
            smtp.Disconnect(true);

        }

        public void ForgotPassword(AppUser user, string url, ForgotPasswordDto forgotPassword)
        {

            var message = new MimeMessage();

            message.From.Add(new MailboxAddress("GolfCar", "customar.test.golfcar@gmail.com"));

            message.To.Add(new MailboxAddress(user.Fullname, forgotPassword.Email));
            message.Subject = "Reset Password";

            string emailbody = string.Empty;

            //using (StreamReader streamReader = new StreamReader(Path.Combine(_env.WebRootPath, "Templates", "Reset.html")))
            //{
            //    emailbody = streamReader.ReadToEnd();
            //}



            emailbody = emailbody.Replace("{{fullname}}", $"{user.Fullname}").Replace("{{code}}", $"{url}");

            message.Body = new TextPart(TextFormat.Html) { Text = emailbody };

            using var smtp = new SmtpClient();

            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("customar.test.golfcar@gmail.com", "psutapkrmjbciuct");
            smtp.Send(message);
            smtp.Disconnect(true);

        }
    }
}

