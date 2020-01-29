using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace WebApplication13.Models
{
    public class Actor
    {

        [Key]
        public int Actor_id { get; set; }
        [Required]
        public string First_name { get; set; }
        [Required]
        public string Last_name { get; set; }
        [Required]
        public DateTime Last_update { get; set; }



        /*
USE [sakila]
GO

       SET ANSI_NULLS ON
        GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE[dbo].[actor]
        (

   [actor_id][int] IDENTITY(1,1) NOT NULL,

  [first_name] [varchar] (45) NOT NULL,

   [last_name] [varchar] (45) NOT NULL,

    [last_update] [datetime]  NOT NULL, PRIMARY KEY NONCLUSTERED
(
    [actor_id] ASC
)WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]
) ON[PRIMARY]
GO

ALTER TABLE[dbo].[actor] ADD CONSTRAINT[DF_actor_last_update]  DEFAULT(getdate()) FOR[last_update]
GO


        */
    }
}
