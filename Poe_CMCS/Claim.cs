using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Claim
{
    

    public string ClaimID { get; set; }
    public string FirstName { get; set; }  
    public string Surname { get; set; }
    public string HoursWorked { get; set; }
    public string HourlyRate { get; set; }
    public string AdditionalNotes { get; set; }
    public string SupportingDocument { get; set; }
    public string Status { get; set; }

    public string claimsDataGrid { get; set; }
    public string Lecturer { get; internal set; }
    public string ClaimDetails { get; internal set; }
}

