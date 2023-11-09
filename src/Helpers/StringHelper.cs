using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using VisitorTrackSystem.src.Common;

namespace VisitorTrackSystem.src.Helpers
{
    public class StringHelper
    {
        /*
        * 文字列がNULLか空白かを判定 
        * @Pram value
        * return true : Null  false : NotNull
        */
        public Boolean IsValueNull(String value)
        {
            return string.IsNullOrEmpty(value);
        }

        /*
        * ユーザーIDが半角英数字4文字以上８文字以内かを判定
        * @Pram userId
        * return true : UnMatch  false : Match
        */
        public Boolean ValidateUserId(String userId)
        {
            string pattern = "^(?=.*\\d)(?=.*[a-zA-Z]).{4,8}$";
            return !Regex.IsMatch(userId, pattern);
        }

        /*
        * メールアドレス形式かの判定
        * @Pram email
        * return true : UnMatch  false : Match
        */
        public Boolean ValidateEmail(string email)
        {
            string pattern = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
            return !Regex.IsMatch(email, pattern);
        }

        /*
         * パスワードが半角英数字大文字小文字混在8文字以上32文字以内記号なしかを判定
         * @param password
         * return true : UnMatch  false : Match
         */
        public Boolean ValidatePassword(string password)
        {
            string pattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,32}$";
            return !Regex.IsMatch(password, pattern);
        }

        /*
        * 管理者情報更新時のパスワードのNULL判定
        * @Pram1 password
        * @Pram2 confirmPassword
        * @Pram3 errorMessage
        * return true : スルー  false : スルーNG
        */
        public Boolean IsValueUpdatePasswordNull(string password, String confirmPassword, out string errorMessage)
        {
            errorMessage = string.Empty;
            //　パスワードに入力がある、確認用パスワードに入力がない
            if (!IsValueNull(password) && IsValueNull(confirmPassword))
            {
                errorMessage = ErrorMessageConst.INPUT_USER_CONFIRM_PASSWORD_REQUIRED;
                return false;
            }
            // パスワードに入力がない、確認用パスワードに入力がある
            else if (IsValueNull(password) && !IsValueNull(confirmPassword))
            {
                errorMessage = ErrorMessageConst.INPUT_USER_PASSWORD_REQUIRED;
                return false;
            }
            // パスワードと確認用パスワードに入力がない場合はスルー
            else if (!IsValueNull(password) && !IsValueNull(confirmPassword))
            {
            }
            return true;
        }

        /*
        * 管理者情報更新時のパスワードの規約違反判定
        * @Pram1 password
        * @Pram2 confirmPassword
        * @Pram3 errorMessage
        * return true : スルー  false : スルーNG
        */
        public Boolean IsValidateUpdatePassword(string password, string confirmPassword, out string errorMessage)
        {
            errorMessage = string.Empty;
            // パスワードと確認用パスワードに入力がない場合はスルー
            if (!IsValueNull(password) && !IsValueNull(confirmPassword))
            {
                // パスワードに入力がある
                if (!IsValueNull(password))
                {
                    if (ValidatePassword(password))
                    {
                        errorMessage = ErrorMessageConst.INPUT_PASSWORD_RULE;
                        return false;
                    }
                    //　確認用パスワードとパスワードが不一致
                    if (!password.Equals(confirmPassword))
                    {
                        errorMessage = ErrorMessageConst.INPUT_PASSWORD_UNMATCH;
                        return false;
                    }
                }
            }
            return true;
        }

        /*
        * 参拝客の電話番号の形式が正しいか
        * @Pram1 phone
        * return true : 一致してない  false :　一致
        */
        public Boolean IsValidPhone(string phone)
        {
            string phoneNumberPattern = @"^(0\d{10}|\d{10})$";
            return !Regex.IsMatch(phone, phoneNumberPattern); 
        }
        /*
        * 参拝客の郵便番号の形式が正しいか
        * @Pram1 postalCode
        * return true : 一致してない  false :　一致
        */
        public Boolean IsValidPostalCode(string postalCode)
        {
            string postalCodePattern = @"^\d{7}$";
            return !Regex.IsMatch(postalCode, postalCodePattern);
        }

        /*
        * 参拝客の初穂料の金額の形式が正しいか
        * @Pram1 firstfruitsFee
        * return true : 一致してない  false :　一致
        */
        public Boolean IsValidFirstfruitsFee(string firstfruitsFee)
        {
            // 正規表現パターン
            string pattern = @"^\d+$";
            return !Regex.IsMatch(firstfruitsFee, pattern);  // true : 一致 false : 一致しない
        }
    }
}
