using System;
using System.Text.RegularExpressions;

namespace Requirement_3
{
    public class Program
    {
        // Validate the registrationNo based on the given rules
        static bool ValidateRegistrationNo(string registrationNo)
        {
            try
            {
                // Check for null or empty input
                if (string.IsNullOrWhiteSpace(registrationNo))
                    return false;

                /*
                 1. First part: 2 uppercase letters (State/UT code)
                 2. Second part: 1–2 digits (District code)
                 3. Third part: 0–2 uppercase letters (optional series)
                 4. Fourth part: 1–4 digits (unique number)
                 5. Each part separated by a space
                */
                string pattern = @"^[A-Z]{2}\s[0-9]{1,2}(?:\s[A-Z]{1,2})?\s[0-9]{1,4}$";

                return Regex.IsMatch(registrationNo, pattern);
            }
            catch (ArgumentNullException)
            {
                // Handles null input passed to Regex
                return false;
            }
            catch (Exception)
            {
              return false;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the registration number of the vehicle:");

            try
            {
                string registrationNo = Console.ReadLine();
                if (ValidateRegistrationNo(registrationNo))
                {
                    Console.WriteLine("Registration No. is valid");
                }
                else
                {
                    Console.WriteLine("Registration No. is invalid");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
