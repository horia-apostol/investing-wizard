using InvestingWizard.Application.Shared.Interfaces;
using InvestingWizard.Identity.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.DependencyInjection;

namespace InvestingWizard.Identity.Services
{
    public class EmailSender : IEmailSender<ApplicationUser>
    {
        private readonly EmailSettings _emailSettings;
        private readonly IServiceProvider _serviceProvider;

        public EmailSender(IOptions<EmailSettings> emailSettings, IServiceProvider serviceProvider)
        {
            _emailSettings = emailSettings.Value;
            _serviceProvider = serviceProvider;
        }

        public async Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var loggingService = scope.ServiceProvider.GetRequiredService<ILoggingService>();

                var client = new SendGridClient(_emailSettings.ApiKey);
                var plainTextContent = $"Please confirm your account by clicking this link: {confirmationLink}";
                var htmlContent = $"Please confirm your account by clicking <a href=\"{confirmationLink}\">here</a>.";
                var message = MailHelper.CreateSingleEmail(
                    new EmailAddress(_emailSettings.FromAddress, _emailSettings.FromName),
                    new EmailAddress(email),
                    "Confirm your email",
                    plainTextContent,
                    htmlContent);
                var response = await client.SendEmailAsync(message);

                loggingService.LogInformation($"Email sent with status: {response.StatusCode}");
            }
        }

        public Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
        {
            throw new NotImplementedException();
        }

        public async Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var loggingService = scope.ServiceProvider.GetRequiredService<ILoggingService>();

                var client = new SendGridClient(_emailSettings.ApiKey);
                var plainTextContent = $"Reset your password by clicking this link: {resetLink}";
                var htmlContent = $"Reset your password by clicking <a href=\"{resetLink}\">here</a>.";
                var message = MailHelper.CreateSingleEmail(
                    new EmailAddress(_emailSettings.FromAddress, _emailSettings.FromName),
                    new EmailAddress(email),
                    "Reset your password",
                    plainTextContent,
                    htmlContent);
                var response = await client.SendEmailAsync(message);

                loggingService.LogInformation($"Email sent with status: {response.StatusCode}");
            }
        }
    }
}
