using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace WebApplication13.Models
{
    public class Film_text
    {
        [Key]
        public Int16 Film_id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        
    }
}

/*
 * 
 USE [sakila]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE[dbo].[film_text]
(

   [film_id][smallint] NOT NULL,  C# datatype Int16

   [title] [varchar] (255) NOT NULL,  C# datatype string

    [description] [text] NULL, PRIMARY KEY NONCLUSTERED  C# datatype string
(
    [film_id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY] TEXTIMAGE_ON[PRIMARY]
GO


*/