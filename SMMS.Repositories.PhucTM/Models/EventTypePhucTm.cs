﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace SMMS.Repositories.PhucTM.Models;

public partial class EventTypePhucTm
{
    public int EventTypePhucTmid { get; set; }

    public string TypeName { get; set; }

    public string Description { get; set; }

    public string SeverityLevel { get; set; }

    public virtual ICollection<MedicalEventPhucTm> MedicalEventPhucTms { get; set; } = new List<MedicalEventPhucTm>();
}