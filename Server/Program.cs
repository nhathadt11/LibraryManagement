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
                BasicHttpBinding abc = new BasicHttpBinding();
                abc.MaxBufferPoolSize = int.MaxValue;
                abc.MaxBufferSize = int.MaxValue;
                abc.MaxReceivedMessageSize = int.MaxValue;
                abc.ReaderQuotas.MaxArrayLength = int.MaxValue;
                abc.ReaderQuotas.MaxStringContentLength = int.MaxValue;
                abc.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
                abc.ReaderQuotas.MaxDepth = int.MaxValue;
                abc.ReaderQuotas.MaxNameTableCharCount = int.MaxValue;
                abc.ReaderQuotas.MaxStringContentLength = int.MaxValue;
                TimeSpan tp = TimeSpan.FromMinutes(30);
                abc.MaxBufferSize = int.MaxValue;
                abc.ReceiveTimeout = tp;
                abc.SendTimeout = tp;

                ServiceMetadataBehavior bh = new ServiceMetadataBehavior();
                bh.HttpGetEnabled = true;

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
                authorHost.AddServiceEndpoint(typeof(Service.IAuthorService), abc, "");
                authorHost.Description.Behaviors.Add(bh);
                authorHost.Open();

                ServiceHost bookCopyHost = new ServiceHost(typeof(Service.BookCopyService), bookCopyAddress);
                bookCopyHost.AddServiceEndpoint(typeof(Service.IBookCopyService), abc, "");
                bh = new ServiceMetadataBehavior();
                bh.HttpGetEnabled = true;
                bookCopyHost.Description.Behaviors.Add(bh);
                bookCopyHost.Open();

                ServiceHost bookHost = new ServiceHost(typeof(Service.BookService), bookAddress);
                bookHost.AddServiceEndpoint(typeof(Service.IBookService), abc, "");
                bh = new ServiceMetadataBehavior();
                bh.HttpGetEnabled = true;
                bookHost.Description.Behaviors.Add(bh);
                bookHost.Open();

                ServiceHost categoryHost = new ServiceHost(typeof(Service.CategoryService), categoryAddress);
                categoryHost.AddServiceEndpoint(typeof(Service.ICategoryService), abc, "");
                bh = new ServiceMetadataBehavior();
                bh.HttpGetEnabled = true;
                categoryHost.Description.Behaviors.Add(bh);
                categoryHost.Open();

                //ServiceHost loanDetailHost = new ServiceHost(typeof(Service.LoanDetailService), loanDetailAddress);
                //loanDetailHost.AddServiceEndpoint(typeof(Service.ILoanDetailService), abc, "");
                //loanDetailHost.Description.Behaviors.Add(bh);
                //loanDetailHost.Open();

                //ServiceHost loanHost = new ServiceHost(typeof(Service.LoanService), loanAddress);
                //loanHost.AddServiceEndpoint(typeof(Service.ILoanService), abc, "");
                //loanHost.Description.Behaviors.Add(bh);
                //loanHost.Open();

                ServiceHost publisherHost = new ServiceHost(typeof(Service.PublisherService), publisherAddress);
                publisherHost.AddServiceEndpoint(typeof(Service.IPublisherService), abc, "");
                bh = new ServiceMetadataBehavior();
                bh.HttpGetEnabled = true;
                publisherHost.Description.Behaviors.Add(bh);
                publisherHost.Open();

                ServiceHost roleHost = new ServiceHost(typeof(Service.RoleService), roleAddress);
                roleHost.AddServiceEndpoint(typeof(Service.IRoleService), abc, "");
                bh = new ServiceMetadataBehavior();
                bh.HttpGetEnabled = true;
                roleHost.Description.Behaviors.Add(bh);
                roleHost.Open();

                ServiceHost userHost = new ServiceHost(typeof(Service.UserService), userAddress);
                userHost.AddServiceEndpoint(typeof(Service.IUserService), abc, "");
                bh = new ServiceMetadataBehavior();
                bh.HttpGetEnabled = true;
                userHost.Description.Behaviors.Add(bh);
                userHost.Open();

                Console.WriteLine("Server started...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
