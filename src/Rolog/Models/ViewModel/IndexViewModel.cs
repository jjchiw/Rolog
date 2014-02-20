/*
 * Created by SharpDevelop.
 * User: JuanJ
 * Date: 2/20/2014
 * Time: 8:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace Rolog.Models.ViewModel
{
	/// <summary>
	/// Description of IndexViewModel.
	/// </summary>
	public class IndexViewModel
    {
        public string ErrorMessage { get; set; }

        public bool HasError
        {
            get { return !string.IsNullOrWhiteSpace(ErrorMessage); }
        }
    }
}
