using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for VaahanResultData
/// </summary>
public class VaahanResultData
{
    public VaahanResultData()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string message { get; set; }
    public string fuel { get; set; }
    public string maker { get; set; }
    public string vchType { get; set; }
    public string norms { get; set; }
    public string vchCatg { get; set; }
    public string regnDate { get; set; }
    public string hsrpFrontLaserCode { get; set; }
    public string hsrpRearLaserCode { get; set; }
    public string stateCd { get; set; }
    public string offCd { get; set; }
    public string mobileNumberValidation { get; set; }
    public bool HasValue { get; set; }
}