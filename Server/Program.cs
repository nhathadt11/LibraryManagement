using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                BasicHttpBinding httpBiding = new BasicHttpBinding();
                httpBiding.MaxBufferPoolSize = int.MaxValue;
                httpBiding.MaxBufferSize = int.MaxValue;
                httpBiding.MaxReceivedMessageSize = int.MaxValue;
                httpBiding.ReaderQuotas.MaxArrayLength = int.MaxValue;
                httpBiding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
                httpBiding.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
                httpBiding.ReaderQuotas.MaxDepth = int.MaxValue;
                httpBiding.ReaderQuotas.MaxNameTableCharCount = int.MaxValue;
                httpBiding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
                TimeSpan tp = TimeSpan.FromMinutes(30);
                httpBiding.MaxBufferSize = int.MaxValue;
                httpBiding.ReceiveTimeout = tp;
                httpBiding.SendTimeout = tp;

                ServiceMetadataBehavior metadataBehavior = new ServiceMetadataBehavior();
                metadataBehavior.HttpGetEnabled = true;

                Uri authorAddress =       new Uri("http://localhost:8888/AuthorService");
                Uri bookCopyAddress =     new Uri("http://localhost:8888/BookCopyService");
                Uri bookAddress =         new Uri("http://localhost:8888/BookService");
                Uri categoryAddress =     new Uri("http://localhost:8888/CategoryService");
                Uri loanDetailAddress =   new Uri("http://localhost:8888/LoanDetailService");
                Uri loanAddress =         new Uri("http://localhost:8888/LoanService");
                Uri publisherAddress =    new Uri("http://localhost:8888/PublisherService");
                Uri roleAddress =         new Uri("http://localhost:8888/RoleService");
                Uri userAddress =         new Uri("http://localhost:8888/UserService");

                ServiceHost authorHost = new ServiceHost(typeof(Service.AuthorService), authorAddress);
                authorHost.AddServiceEndpoint(typeof(Service.IAuthorService), httpBiding, "");
                authorHost.Description.Behaviors.Add(metadataBehavior);
                authorHost.Open();

                ServiceHost bookCopyHost = new ServiceHost(typeof(Service.BookCopyService), bookCopyAddress);
                bookCopyHost.AddServiceEndpoint(typeof(Service.IBookCopyService), httpBiding, "");
                metadataBehavior = new ServiceMetadataBehavior();
                metadataBehavior.HttpGetEnabled = true;
                bookCopyHost.Description.Behaviors.Add(metadataBehavior);
                bookCopyHost.Open();

                ServiceHost bookHost = new ServiceHost(typeof(Service.BookService), bookAddress);
                bookHost.AddServiceEndpoint(typeof(Service.IBookService), httpBiding, "");
                metadataBehavior = new ServiceMetadataBehavior();
                metadataBehavior.HttpGetEnabled = true;
                bookHost.Description.Behaviors.Add(metadataBehavior);
                bookHost.Open();

                ServiceHost categoryHost = new ServiceHost(typeof(Service.CategoryService), categoryAddress);
                categoryHost.AddServiceEndpoint(typeof(Service.ICategoryService), httpBiding, "");
                metadataBehavior = new ServiceMetadataBehavior();
                metadataBehavior.HttpGetEnabled = true;
                categoryHost.Description.Behaviors.Add(metadataBehavior);
                categoryHost.Open();

                ServiceHost loanDetailHost = new ServiceHost(typeof(Service.LoanDetailService), loanDetailAddress);
                loanDetailHost.AddServiceEndpoint(typeof(Service.ILoanDetailService), httpBiding, "");
                metadataBehavior = new ServiceMetadataBehavior();
                metadataBehavior.HttpGetEnabled = true;
                loanDetailHost.Description.Behaviors.Add(metadataBehavior);
                loanDetailHost.Open();

                ServiceHost loanHost = new ServiceHost(typeof(Service.LoanService), loanAddress);
                loanHost.AddServiceEndpoint(typeof(Service.ILoanService), httpBiding, "");
                metadataBehavior = new ServiceMetadataBehavior();
                metadataBehavior.HttpGetEnabled = true;
                loanHost.Description.Behaviors.Add(metadataBehavior);
                loanHost.Open();

                ServiceHost publisherHost = new ServiceHost(typeof(Service.PublisherService), publisherAddress);
                publisherHost.AddServiceEndpoint(typeof(Service.IPublisherService), httpBiding, "");
                metadataBehavior = new ServiceMetadataBehavior();
                metadataBehavior.HttpGetEnabled = true;
                publisherHost.Description.Behaviors.Add(metadataBehavior);
                publisherHost.Open();

                ServiceHost roleHost = new ServiceHost(typeof(Service.RoleService), roleAddress);
                roleHost.AddServiceEndpoint(typeof(Service.IRoleService), httpBiding, "");
                metadataBehavior = new ServiceMetadataBehavior();
                metadataBehavior.HttpGetEnabled = true;
                roleHost.Description.Behaviors.Add(metadataBehavior);
                roleHost.Open();

                ServiceHost userHost = new ServiceHost(typeof(Service.UserService), userAddress);
                userHost.AddServiceEndpoint(typeof(Service.IUserService), httpBiding, "");
                metadataBehavior = new ServiceMetadataBehavior();
                metadataBehavior.HttpGetEnabled = true;
                userHost.Description.Behaviors.Add(metadataBehavior);
                userHost.Open();

                Console.WriteLine("Server started...");
                Console.ReadLine();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
