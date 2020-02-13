using System;
using System.Collections.Generic;
using KtpAcsMiddleware.AppService._Dependency;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.KtpApiService;
using KtpAcsMiddleware.KtpApiService.Api;
using KtpAcsMiddleware.KtpApiService.Device;
using KtpAcsMiddleware.KtpApiService.PanelApi;
using KtpAcsMiddleware.KtpApiService.PanelApi.PanelMage;
using static KtpAcsMiddleware.KtpApiService.PanelApi.PanelLibrarySend;
using System.ComponentModel;
using RestSharp;
using static KtpAcsMiddleware.KtpApiService.PanelApi.PanelWorkerSend;
using KtpAcsMiddleware.KtpApiService.PanelApiCd.CdModel;
using KtpAcsMiddleware.KtpApiService.TeamWorkers.Model;
using KtpAcsMiddleware.KtpApiService.TeamWorkers;
using KtpAcsMiddleware.KtpApiService.PanelApiCd;
using System.Text.RegularExpressions;
using System.Text;

namespace KtpAcsMiddleware.Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {

                string usernamePassword = "admin:admin";

                byte[] bytes = Encoding.Default.GetBytes(usernamePassword);
                string str = Convert.ToBase64String(bytes);
                Console.WriteLine(str);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                LogHelper.ExceptionLog(ex);
                Console.WriteLine(ex);
                Console.ReadLine();
            }
            Console.WriteLine(@"end...");
        }

        public static int RetunPicSize(string picstr)
        {
            int p_size = 0;
            try
            {
                int p_ix = picstr.IndexOf("=");
                int p_len = picstr.Length;
                int fix_len = 0;
                if (p_ix > -1)
                {
                    fix_len = p_len - p_ix;
                }
                p_size = p_len - (p_len / 8) * 2 - fix_len;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return p_size;
        }
        int CMailCoderBase64EncodeSize(int iSize)
        {
            int nSize, nCR;
            nSize = (iSize + 2) / 3 * 4;
            nCR = nSize;
            nSize += nCR * 2;
            return nSize;
        }
    }
}