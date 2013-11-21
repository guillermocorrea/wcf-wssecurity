using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace PruebaDeceval.Infraestructure
{
    public class DecevalClient
    {
        public void Client()
        {
            // Create the binding.
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.TransportWithMessageCredential;
            myBinding.Security.Message.ClientCredentialType =
                MessageCredentialType.Certificate;

            // Disable credential negotiation and the establishment of 
            // a security context.
            myBinding.Security.Message.NegotiateServiceCredential = false;
            myBinding.Security.Message.EstablishSecurityContext = false;

            // Create the endpoint address. 
            EndpointAddress ea = new
                EndpointAddress("https://pruebas.deceval.com.co:446/sdlservices/SDLService");

            // Create the client. 
            SDLServiceClient client = new SDLServiceClient(myBinding, ea);
            //CalculatorClient cc =
            //    new CalculatorClient(myBinding, ea);

            // Specify a certificate to use for authenticating the client.
            client.ClientCredentials.ClientCertificate.SetCertificate(
                StoreLocation.CurrentUser,
                StoreName.My,
                X509FindType.FindBySubjectName,
                "tempClientcert");
            //client.ClientCredentials.ClientCertificate.SetCertificate(
            //    StoreLocation.LocalMachine,
            //    StoreName.TrustedPeople,
            //    X509FindType.FindBySubjectName,
            //    "www.deceval.com");

            // Specify a default certificate for the service.
            //client.ClientCredentials.ServiceCertificate.SetDefaultCertificate(
            //    StoreLocation.LocalMachine,
            //    StoreName.TrustedPeople,
            //    X509FindType.FindBySubjectName,
            //    "dcta102");

            // Begin using the client.
            try
            {
                client.Open();
                Console.WriteLine(client.cancelacionPagares(null));
                Console.ReadLine();

                // Close the client.
                client.Close();
            }
            catch (Exception e)
            {

            }
        }
    }
}