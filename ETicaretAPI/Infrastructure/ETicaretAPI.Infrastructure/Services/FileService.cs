﻿
using ETicaretAPI.Infrastructure.Operations;
using FluentValidation.Internal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services
{
    public class FileService
    {
        //   async Task<string> FileRenameAsync(string pathOrContainerName, string fileName, /*HasFile hasFileMethod*/ bool first = true)
        //{
        //    string newFileName = await Task.Run<string>(async () =>
        //    {
        //        string extension = Path.GetExtension(fileName);

        //        string newFileName = fileName;
        //        if (first)
        //        {
        //            string oldName = Path.GetFileNameWithoutExtension(fileName);
        //            newFileName = $"{NameOperation.CharacterRegulatory(oldName)}{extension}";
        //        }
        //        else
        //        {
        //            newFileName = fileName;
        //            int indexNo1 = newFileName.IndexOf('-');
        //            if (indexNo1 == -1)
        //                newFileName = $"{Path.GetFileNameWithoutExtension(newFileName)}-2{extension}";
        //            else
        //            {
        //                int lastIndex = 0;
        //                while (newFileName.IndexOf("-", indexNo1 + 1) != -1)
        //                {
        //                    lastIndex = indexNo1;
        //                    indexNo1 = newFileName.IndexOf('-', indexNo1 + 1);
        //                    indexNo1 = lastIndex;
        //                    if (indexNo1 == -1)
        //                    {
        //                        indexNo1 = lastIndex;
        //                        break;
        //                    }
        //                }

        //                int indexNo2 = newFileName.IndexOf(".");
        //                string fileNo = newFileName.Substring(indexNo1 + 1, indexNo2 - indexNo1 - 1);

        //                if (int.TryParse(fileNo, out int _fileNo))
        //                {
        //                    _fileNo++;
        //                    newFileName = newFileName.Remove(indexNo1 + 1, indexNo2 - indexNo1 - 1)
        //                                         .Insert(indexNo1 + 1, _fileNo.ToString());
        //                }
        //                else
        //                    newFileName = $"{Path.GetFileNameWithoutExtension(newFileName)}-2{extension}";
        //            }
        //        }

        //        //if (File.Exists($"{path}\\{newFileName}"))
        //        //if (hasFileMethod(pathOrContainerName, newFileName))
        //        //    return await FileRenameAsync(pathOrContainerName, newFileName, hasFileMethod, false);
        //        //else
        //        return newFileName;
        //    });
        //    return newFileName;
        //}
    }
}
