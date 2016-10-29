using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Questionario
/// </summary>
public class Questionario
{
    public int id_questao { get; set; }

    public string questao { get; set; }

    public int vlr_resposta { get; set; }

    public int id_problema { get; set; }
}