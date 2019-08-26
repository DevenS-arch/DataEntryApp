﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DataEntryApp.DAC.POCOEntities;
using static AutoMapper.Mapper;

namespace DataEntryApp.DAC
{
    public class EmailTemplateFieldsDAL
    {

        public static List<EmailTemplateField> GetEmailTemplateFields(string emailTemplateId)
        {
            using (var dbSession = DocumentStoreHolder.Store.OpenSession())
            {

                try
                {
                    var emailTemplateFeilds = dbSession.Query<EmailTemplateField>()
                                     .Where(et => et.EmailTemplateId == emailTemplateId).ToList();

                   // var emailTemplateFeildsDTO = Map<EmailTemplateField>(emailTemplateFeilds);


                    return emailTemplateFeilds;
                }
                catch
                {
                    dbSession.Advanced.Clear();
                    throw;
                }

            }
        }
    }
}