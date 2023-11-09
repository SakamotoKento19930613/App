using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VisitorTrackSystem.src.Common;
using VisitorTrackSystem.src.Entity;
using VisitorTrackSystem.src.Helpers;
using VisitorTrackSystem.src.Models.Worship;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace VisitorTrackSystem.src.Service.Worshipers
{
    internal class WorshipService
    {
        //参拝客・個人登録時の規約違反チェック

        //氏名
        public Boolean IsValueName(string lastName, string firstName, string lastNameKana, string firstNameKana, out string errorMessage)
        {
            errorMessage = string.Empty;
            //NULL判定
            if (string.IsNullOrEmpty(lastName))
            {
                errorMessage = ErrorMessageConst.LASTNAME_IS_NULL;
                return false;
            }
            if (string.IsNullOrEmpty(firstName))
            {
                errorMessage = ErrorMessageConst.FIRSTNAME_IS_NULL;
                return false;
            }
            if (string.IsNullOrEmpty(lastNameKana))
            {
                errorMessage = ErrorMessageConst.LASTNAMEKANA_IS_NULL;
                return false;
            }
            if (string.IsNullOrEmpty(firstNameKana))
            {
                errorMessage = ErrorMessageConst.FIRSTNAMEKANA_IS_NULL;
                return false;
            }
            return true;
        }

        //生年月日
        public Boolean IsValueBirth(DateTime birth, out string errorMessage)
        {
            errorMessage = string.Empty;

            //NULL判定
            if (birth == null)
            {
                errorMessage = ErrorMessageConst.BIRH_IS_NULL;
                return false;
            }
            //日付の形式かを判定
            try
            {
                DateTime validDate = DateTime.Parse(birth.ToString()); // 例外を発生させないために一度 `ToString()` を経由
                return true; // 有効な日付
            }
            catch (FormatException)
            {
                errorMessage = ErrorMessageConst.BIRH_IS_FORMAT_ERROR;
                return false; // 無効な日付
            }
        }

        //メールアドレス
        public Boolean IsValueEmail(string email, out string errorMessage)
        {
            errorMessage = string.Empty;
            //NULL判定
            if (string.IsNullOrEmpty(email))
            {
                errorMessage = ErrorMessageConst.AUTHCODE_EMAIL_REQUIRED;
                return false;
            }
            //メールアドレスの形式か
            StringHelper stringHelper = new StringHelper();
            if (stringHelper.ValidateEmail(email))
            {
                //不一致
                errorMessage = ErrorMessageConst.INPUT_EMAIL_RULE;
                return false;
            }

            return true;
        }

        //電話番号
        public Boolean IsValuePhone(string phone, out string errorMessage)
        {
            //NULL判定
            errorMessage = string.Empty;
            if (string.IsNullOrEmpty(phone))
            {
                errorMessage = ErrorMessageConst.PHONE_IS_NONE;
                return false;
            }

            //形式が電話番号か（固定か携帯の番号形式か）
            StringHelper stringHelper = new StringHelper();
            if (stringHelper.IsValidPhone(phone))
            {
                errorMessage = ErrorMessageConst.PHONE_IS_FORMAT_ERROR;
                return false;
            }
            return true;
        }

        //郵便番号
        public Boolean IsValuePostalCode(string postalCode, out string errorMessage)
        {
            errorMessage = string.Empty;
            //NULL判定
            if (string.IsNullOrEmpty(postalCode))
            {
                errorMessage = ErrorMessageConst.POSTALCODE_IS_NONE;
                return false;
            }
            //形式が郵便番号（数字７桁）か
            StringHelper stringHelper = new StringHelper();
            if (stringHelper.IsValidPostalCode(postalCode))
            {
                errorMessage = ErrorMessageConst.POSTALCODE_IS_FORMAT_ERROR;
                return false;
            }
            return true;
        }
        public Boolean IsValueAddress(string pref, string city, string street, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrEmpty(pref) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(street))
            {
                errorMessage = ErrorMessageConst.ADDRESS_IS_NULL;
                return false;
            }
            return true;
        }

        public Boolean IsValuePrayerData(string prayer, string firstfruitsFee, out string errorMessage)
        {
            {
                errorMessage = string.Empty;
                if (string.IsNullOrEmpty(prayer))
                {
                    errorMessage = ErrorMessageConst.PRAYER_IS_NULL;
                    return false;
                }
                if (string.IsNullOrEmpty(firstfruitsFee))
                {
                    errorMessage = ErrorMessageConst.FFF_IS_NULL;
                    return false;
                }

                //初穂料の金額が正しいか（日本円（JPY)の不正値チェック(通貨記号なし））
                StringHelper stringHelper = new StringHelper();
                if (stringHelper.IsValidFirstfruitsFee(firstfruitsFee))
                {
                    errorMessage = ErrorMessageConst.FFF_IS_FORMAT_ERROR;
                    return false;
                }
                return true;
            }
        }

        //参拝客・個人（家族情報なし）の登録
        public Boolean InsertFunction(string lastName, string firstName, string fullName, string lastNameKana, string firstNameKana,
            DateTime birthData, string email, string phone,
                string postalCode, string pref, string city, string street, string building,
                string prayer, int firstfruitsFeeVal, int notiffcationMethod, string note, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {

                UserSession userSession = new UserSession();
                WorshipModel worshipModel = new WorshipModel();
                //登録者のIDをセッションから取得
                int loginUserId = worshipModel.getLoginUserId();
                //参拝客・個人の登録処理
                worshipModel.InsertWorship(loginUserId, lastName, firstName, fullName, lastNameKana, firstNameKana, birthData, email, phone,
                    postalCode, pref, city, street, building, prayer, firstfruitsFeeVal, notiffcationMethod, note);
                return true;
            } catch (Exception ex)
            {
                errorMessage = "エラーが発生しました: " + ex.Message;
                return false;
            }
        }

        public Boolean InsertFunctionCompany(string companyName, string companyNameKana, string presFirstName, string presLastName, string presLastNameKana, string presFirstNameKana, string email, string phone,
               string postalCode, string pref, string city, string street, string building, string prayer, int firstfruitsFeeVal, int notiffcationMethod, string note, out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                UserSession userSession = new UserSession();
                WorshipModel worshipModel = new WorshipModel();
                //登録者のIDをセッションから取得
                int loginUserId = worshipModel.getLoginUserId();
                //参拝客・団体の登録処理
                worshipModel.InsertWorshipCompany(loginUserId, companyName, companyNameKana, presFirstName, presLastName, presLastNameKana, presFirstNameKana, email, phone,
                    postalCode, pref, city, street, building, prayer, firstfruitsFeeVal, notiffcationMethod, note);
                return true;
            }
            catch (Exception ex)
            {
                errorMessage = "エラーが発生しました: " + ex.Message;
                return false;
            }
        }
    }
}
            