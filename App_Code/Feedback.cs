using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Feedback
/// </summary>
public class Feedback
{
    public int id_feedback { get; set; }

    public string detalhe_feedback { get; set; }

    public DateTime dt_feedback { get; set; }

    public int id_solucao { get; set; }
    public static int Text { get; set; }
}