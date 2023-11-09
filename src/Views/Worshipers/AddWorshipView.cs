using Manage753.src.Helpers;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using VisitorTrackSystem.src.Common;
using VisitorTrackSystem.src.Helpers;
using VisitorTrackSystem.src.Service.Auth;
using VisitorTrackSystem.src.Service.Worshipers;

namespace VisitorTrackSystem.src.Views.Worshipers
{
    public partial class AddWorshipView : Form
    {
        public AddWorshipView()
        {
            InitializeComponent();
            /**
             * 初期設定
             * コントロールボックスの［閉じる］ボタンの無効化
             * InactivityDetected イベントをハンドル
             **/
            AppUserActivityDetector.UserActivityDetector.InactivityDetected += OnInactivityDetected;
            IntPtr hMenu = GetSystemMenu(this.Handle, 0);
            RemoveMenu(hMenu, SC_CLOSE, MF_BYCOMMAND);
            //配偶者、兄弟姉妹、子供の有無は初期表示では無
            RadioSpouseNONE.Checked = true;
            RadioChildrenNONE.Checked = true;
            RadioSiblingsNONE.Checked = true;
            RadioRelationshipNONE.Checked = true;
            BtnFamilyDataView.Enabled = false;
            //通知方法は初期表示では「ハガキ」に設定
            RadioNotiffcationMethod_HAGAKI.Checked = true;
        }




        //郵便番号1
        private void TxtPostalCode1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtPostalCode1.Text) && !string.IsNullOrEmpty(TxtPostalCode2.Text))
            {
                string postalCode = TxtPostalCode1.Text + TxtPostalCode2.Text;
                AddressHelper addressHelper = new AddressHelper();
                if (addressHelper.PostalCodeExists(postalCode))
                {
                    var data = addressHelper.GetAddressData(postalCode);
                    string prefecture = data.Prefecture;
                    string city = data.City;
                    // 対応する都道府県と市区町村を設定
                    CmbPref.SelectedItem = prefecture;
                    TxtCity.Text = city;
                }
            }
        }
        //郵便番号2
        private void TxtPostalCode2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtPostalCode1.Text) && !string.IsNullOrEmpty(TxtPostalCode2.Text))
            {
                string postalCode = TxtPostalCode1.Text + TxtPostalCode2.Text;
                AddressHelper addressHelper = new AddressHelper();
                if (addressHelper.PostalCodeExists(postalCode))
                {
                    var data = addressHelper.GetAddressData(postalCode);
                    string prefecture = data.Prefecture;
                    string city = data.City;
                    // 対応する都道府県と市区町村を設定
                    CmbPref.SelectedItem = prefecture;
                    TxtCity.Text = city;
                }
            }
        }

        //配偶者無ラジオボタン
        private void RadioSpouseNONE_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioSpouseNONE.Checked && RadioSiblingsNONE.Checked && RadioChildrenNONE.Checked && RadioRelationshipNONE.Checked)
            {
                BtnFamilyDataView.Enabled = false;
            }
            else
            {
                BtnFamilyDataView.Enabled = true;
            }
        }
        //兄弟姉妹無ボタン
        private void RadioSiblingsNONE_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioSpouseNONE.Checked && RadioSiblingsNONE.Checked && RadioChildrenNONE.Checked && RadioRelationshipNONE.Checked)
            {
                BtnFamilyDataView.Enabled = false;
            }
            else
            {
                BtnFamilyDataView.Enabled = true;
            }
        }

        //子供無ラジオボタン
        private void RadioChildrenNONE_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioSpouseNONE.Checked && RadioSiblingsNONE.Checked && RadioChildrenNONE.Checked && RadioRelationshipNONE.Checked)
            {
                BtnFamilyDataView.Enabled = false;
            }
            else
            {
                BtnFamilyDataView.Enabled = true;
            }
        }

        //その他続柄ラジオボタン
        private void RadioRelationshipNONE_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioSpouseNONE.Checked && RadioSiblingsNONE.Checked && RadioChildrenNONE.Checked && RadioRelationshipNONE.Checked)
            {
                BtnFamilyDataView.Enabled = false;
            }
            else
            {
                BtnFamilyDataView.Enabled = true;
            }
        }

        //個人　参拝客の登録
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            WorshipService worshipService = new WorshipService();
            //入力値の取得
            //参拝客氏名
            string lastName = TxtLastName.Text;
            string firstName = TxtFirstName.Text;
            string space = " "; // 半角スペースを含む文字列を定義
            string fullName = lastName + space + firstName;
            string lastNameKana = TxtLastNameKana.Text;
            string firstNameKana = TxtFirstNameKana.Text;
            string fullNameKana = lastNameKana + space + firstNameKana;

            //名前の規約違反の判定
            Boolean nameErrorResult = worshipService.IsValueName(lastName, firstName, lastNameKana, firstNameKana, out string errorMessage);
            if (!nameErrorResult)
            {
                LblErrorMessage.Visible = true;
                LblErrorMessage.Text = errorMessage;
                return;
            }

            //生年月日
            DateTime birthData = DateTime.Parse(TxtBirthDate.Text);

            //生年月日の規約違反の判定
            Boolean birthErrorResult = worshipService.IsValueBirth(birthData, out errorMessage);
            if (!birthErrorResult)
            {
                LblErrorMessage.Visible = true;
                LblErrorMessage.Text = errorMessage;
                return;
            }

            //メールアドレス
            string emailAddress = TxtEmailAddress.Text;
            string domain = CmbDomain.Text;
            string email = emailAddress + domain;

            //電話番号
            string phone1 = TxtPhone1.Text;
            string phone2 = TxtPhone2.Text;
            string phone3 = TxtPhone3.Text;
            string phone = phone1 + phone2 + phone3;

            //郵便番号
            string postalCode1 = TxtPostalCode1.Text;
            string postalCode2 = TxtPostalCode2.Text;
            string postalCode = postalCode1 + postalCode2;

            //住所
            string pref = CmbPref.Text;
            string city = TxtCity.Text;
            string street = TxtStreet.Text;
            string building = TxtBuilding.Text;
            string address = pref + city + street + building;

            //祈願情報
            string prayer = CmbPrayerType.Text;
            string firstfruitsFee = CmbFirstfruitsFee.Text;

            //祈願の規則違反の判定
            Boolean prayerDataErrorResult = worshipService.IsValuePrayerData(prayer, firstfruitsFee, out errorMessage);
            if (!prayerDataErrorResult)
            {
                LblErrorMessage.Visible = true;
                LblErrorMessage.Text = errorMessage;
                return;
            }

            //通知方法
            int notiffcationMethod = 0;
            if (RadioNotiffcationMethod_HAGAKI.Checked)
            {
                notiffcationMethod = 0;
            }
            else if (RadioNotiffcationMethod_SMS.Checked)
            {
                notiffcationMethod = 1;
            }
            else if (RadioNotiffcationMethod_EMAIL.Checked)
            {
                notiffcationMethod = 2;
            }
            else if (RadioNotiffcationMethod_NONE.Checked)
            {
                notiffcationMethod = 3;
            }

            StringHelper stringHelper = new StringHelper();
            //通知方法が0 = HAGAKIの場合は住所の入力を必須にする（電話番号とEMAI必須にはしない）
            if (notiffcationMethod == 0)
            {
                //郵便番号の規約違反の判定
                Boolean postalCodeErrorResult = worshipService.IsValuePostalCode(postalCode, out errorMessage);
                if (!postalCodeErrorResult)
                {
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = errorMessage;
                    return;
                }
                //住所の規約違反の判定
                Boolean addressErrorResult = worshipService.IsValueAddress(pref, city, street, out errorMessage);
                if (!addressErrorResult)
                {
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = errorMessage;
                    return;
                }
                //電話番号とEMAILに入力があった場合はフォーマット確認だけ行う（NULL判定は行わない）
                if (!string.IsNullOrEmpty(phone1) || !string.IsNullOrEmpty(phone2) || !string.IsNullOrEmpty(phone3))
                {
                    if (stringHelper.IsValidPhone(phone))
                    {
                        errorMessage = ErrorMessageConst.PHONE_IS_FORMAT_ERROR;
                        LblErrorMessage.Visible = true;
                        LblErrorMessage.Text = errorMessage;
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(emailAddress))
                {
                    if (stringHelper.ValidateEmail(email))
                    {
                        errorMessage = ErrorMessageConst.INPUT_EMAIL_RULE;
                        LblErrorMessage.Visible = true;
                        LblErrorMessage.Text = errorMessage;
                        return;
                    }
                }
            }
            //通知方法が1 = SMSの場合は電話番号の入力を必須にする（住所とEMAILは必須にしない）
            else if (notiffcationMethod == 1)
            {
                //電話番号の規約違反の判定
                Boolean phoneErrorResult = worshipService.IsValuePhone(phone, out errorMessage);
                if (!phoneErrorResult)
                {
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = errorMessage;
                    return;
                }
                //EMAIと住所に入力があった場合はフォーマット確認だけ行う（NULL判定は行わない）
                if (!string.IsNullOrEmpty(emailAddress))
                {
                    if (stringHelper.ValidateEmail(email))
                    {
                        errorMessage = ErrorMessageConst.INPUT_EMAIL_RULE;
                        LblErrorMessage.Visible = true;
                        LblErrorMessage.Text = errorMessage;
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(postalCode))
                {
                    if (stringHelper.IsValidPostalCode(postalCode))
                    {
                        errorMessage = ErrorMessageConst.POSTALCODE_IS_FORMAT_ERROR;
                        LblErrorMessage.Visible = true;
                        LblErrorMessage.Text = errorMessage;
                        return;
                    }
                }
                //通知方法が2 = EMAILの場合はメールアドレスの入力を必須にする（電話番号と住所は必須にしない）
                else if (notiffcationMethod == 2)
                {
                    //メールアドレスの規約違反の判定
                    Boolean emailErrorResult = worshipService.IsValueEmail(email, out errorMessage);
                    if (!emailErrorResult)
                    {
                        LblErrorMessage.Visible = true;
                        LblErrorMessage.Text = errorMessage;
                        return;
                    }

                    //電話番号と住所に入力があったらフォーマットの確認だけ行う
                    if (!string.IsNullOrEmpty(phone1) || !string.IsNullOrEmpty(phone2) || !string.IsNullOrEmpty(phone3))
                    {
                        if (stringHelper.IsValidPhone(phone))
                        {
                            errorMessage = ErrorMessageConst.PHONE_IS_FORMAT_ERROR;
                            LblErrorMessage.Visible = true;
                            LblErrorMessage.Text = errorMessage;
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(postalCode))
                    {
                        if (stringHelper.IsValidPostalCode(postalCode))
                        {
                            errorMessage = ErrorMessageConst.POSTALCODE_IS_FORMAT_ERROR;
                            LblErrorMessage.Visible = true;
                            LblErrorMessage.Text = errorMessage;
                            return;
                        }
                    }
                }
                //通知方法が3 = 希望しないの場合は電話番号、メールアドレス、住所の入力を必須にしない
                else if (notiffcationMethod == 3)
                {
                    //メールアドレス、電話番号、住所に入力があったらフォーマットの確認を行う
                    if (!string.IsNullOrEmpty(emailAddress))
                    {
                        if (stringHelper.ValidateEmail(email))
                        {
                            errorMessage = ErrorMessageConst.INPUT_EMAIL_RULE;
                            LblErrorMessage.Visible = true;
                            LblErrorMessage.Text = errorMessage;
                            return;
                        }
                        if (!string.IsNullOrEmpty(phone1) || !string.IsNullOrEmpty(phone2) || !string.IsNullOrEmpty(phone3))
                        {
                            if (stringHelper.IsValidPhone(phone))
                            {
                                errorMessage = ErrorMessageConst.PHONE_IS_FORMAT_ERROR;
                                LblErrorMessage.Visible = true;
                                LblErrorMessage.Text = errorMessage;
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(postalCode))
                        {
                            if (stringHelper.IsValidPostalCode(postalCode))
                            {
                                errorMessage = ErrorMessageConst.POSTALCODE_IS_FORMAT_ERROR;
                                LblErrorMessage.Visible = true;
                                LblErrorMessage.Text = errorMessage;
                                return;
                            }
                        }
                    }
                }
            }

            // ご家族の情報
            //true = 有 false = 無
            Boolean spouse = false; 
            Boolean sibling = false;
            Boolean chiildren = false;
            Boolean others = false;

            if (RadioSpouseYES.Checked)
            {
                spouse = true;
            } else
            {
                spouse = false;
            }
            if (RadioSiblingsYES.Checked)
            {
                sibling = true;
            }
            else
            {
                sibling = false;
            }
            if (RadioChildrenYES.Checked)
            {
                chiildren = true;
            }else
            {
                chiildren = false;
            }
            if (RadioRelationshipYES.Checked)
            {
                others = true;
            }
            else
            {
                others = false;
            }

            //家族情報が有なのに家族情報入力画面に進んでないと登録はできない
            if (spouse || sibling || chiildren || others)
            {
                LblErrorMessage.Text = ErrorMessageConst.FAMIRY_DATA_IS_NULL;
                LblErrorMessage.Visible = true;
                return;
            }

            //備考
            string note = TxtNote.Text;

            //初穂料を数値へコンバート
            int firstfruitsFeeVal = int.Parse(CmbFirstfruitsFee.Text);

            Boolean insertResult = worshipService.InsertFunction(lastName, firstName, fullName, lastNameKana, firstNameKana, birthData, email, phone,
                postalCode, pref, city, street, building, prayer, firstfruitsFeeVal, notiffcationMethod, note, out errorMessage);

            if (!insertResult)
            {
                //登録に失敗しました。
            }
            //登録に成功
            MessageBox.Show("成功しました");
        }

        //家族情報入力ボタン
        private void BtnFamilyDataView_Click(object sender, EventArgs e)
        {
            WorshipService worshipService = new WorshipService();
            //入力値の取得
            //参拝客氏名
            string lastName = TxtLastName.Text;
            string firstName = TxtFirstName.Text;
            string space = " "; // 半角スペースを含む文字列を定義
            string fullName = lastName + space + firstName;
            string lastNameKana = TxtLastNameKana.Text;
            string firstNameKana = TxtFirstNameKana.Text;
            string fullNameKana = lastNameKana + space + firstNameKana;

            //名前の規約違反の判定
            Boolean nameErrorResult = worshipService.IsValueName(lastName, firstName, lastNameKana, firstNameKana, out string errorMessage);
            if (!nameErrorResult)
            {
                LblErrorMessage.Visible = true;
                LblErrorMessage.Text = errorMessage;
                return;
            }

            //生年月日
            DateTime birthData = DateTime.Parse(TxtBirthDate.Text);

            //生年月日の規約違反の判定
            Boolean birthErrorResult = worshipService.IsValueBirth(birthData, out errorMessage);
            if (!birthErrorResult)
            {
                LblErrorMessage.Visible = true;
                LblErrorMessage.Text = errorMessage;
                return;
            }

            //メールアドレス
            string emailAddress = TxtEmailAddress.Text;
            string domain = CmbDomain.Text;
            string email = emailAddress + domain;

            //電話番号
            string phone1 = TxtPhone1.Text;
            string phone2 = TxtPhone2.Text;
            string phone3 = TxtPhone3.Text;
            string phone = phone1 + phone2 + phone3;

            //郵便番号
            string postalCode1 = TxtPostalCode1.Text;
            string postalCode2 = TxtPostalCode2.Text;
            string postalCode = postalCode1 + postalCode2;

            //住所
            string pref = CmbPref.Text;
            string city = TxtCity.Text;
            string street = TxtStreet.Text;
            string building = TxtBuilding.Text;
            string address = pref + city + street + building;

            //祈願情報
            string prayer = CmbPrayerType.Text;
            string firstfruitsFee = CmbFirstfruitsFee.Text;

            //祈願の規則違反の判定
            Boolean prayerDataErrorResult = worshipService.IsValuePrayerData(prayer, firstfruitsFee, out errorMessage);
            if (!prayerDataErrorResult)
            {
                LblErrorMessage.Visible = true;
                LblErrorMessage.Text = errorMessage;
                return;
            }

            //通知方法
            int notiffcationMethod = 0;
            if (RadioNotiffcationMethod_HAGAKI.Checked)
            {
                notiffcationMethod = 0;
            }
            else if (RadioNotiffcationMethod_SMS.Checked)
            {
                notiffcationMethod = 1;
            }
            else if (RadioNotiffcationMethod_EMAIL.Checked)
            {
                notiffcationMethod = 2;
            }
            else if (RadioNotiffcationMethod_NONE.Checked)
            {
                notiffcationMethod = 3;
            }

            StringHelper stringHelper = new StringHelper();
            //通知方法が0 = HAGAKIの場合は住所の入力を必須にする（電話番号とEMAI必須にはしない）
            if (notiffcationMethod == 0)
            {
                //郵便番号の規約違反の判定
                Boolean postalCodeErrorResult = worshipService.IsValuePostalCode(postalCode, out errorMessage);
                if (!postalCodeErrorResult)
                {
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = errorMessage;
                    return;
                }
                //住所の規約違反の判定
                Boolean addressErrorResult = worshipService.IsValueAddress(pref, city, street, out errorMessage);
                if (!addressErrorResult)
                {
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = errorMessage;
                    return;
                }
                //電話番号とEMAILに入力があった場合はフォーマット確認だけ行う（NULL判定は行わない）
                if (!string.IsNullOrEmpty(phone1) || !string.IsNullOrEmpty(phone2) || !string.IsNullOrEmpty(phone3))
                {
                    if (stringHelper.IsValidPhone(phone))
                    {
                        errorMessage = ErrorMessageConst.PHONE_IS_FORMAT_ERROR;
                        LblErrorMessage.Visible = true;
                        LblErrorMessage.Text = errorMessage;
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(emailAddress))
                {
                    if (stringHelper.ValidateEmail(email))
                    {
                        errorMessage = ErrorMessageConst.INPUT_EMAIL_RULE;
                        LblErrorMessage.Visible = true;
                        LblErrorMessage.Text = errorMessage;
                        return;
                    }
                }
            }
            //通知方法が1 = SMSの場合は電話番号の入力を必須にする（住所とEMAILは必須にしない）
            else if (notiffcationMethod == 1)
            {
                //電話番号の規約違反の判定
                Boolean phoneErrorResult = worshipService.IsValuePhone(phone, out errorMessage);
                if (!phoneErrorResult)
                {
                    LblErrorMessage.Visible = true;
                    LblErrorMessage.Text = errorMessage;
                    return;
                }
                //EMAIと住所に入力があった場合はフォーマット確認だけ行う（NULL判定は行わない）
                if (!string.IsNullOrEmpty(emailAddress))
                {
                    if (stringHelper.ValidateEmail(email))
                    {
                        errorMessage = ErrorMessageConst.INPUT_EMAIL_RULE;
                        LblErrorMessage.Visible = true;
                        LblErrorMessage.Text = errorMessage;
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(postalCode))
                {
                    if (stringHelper.IsValidPostalCode(postalCode))
                    {
                        errorMessage = ErrorMessageConst.POSTALCODE_IS_FORMAT_ERROR;
                        LblErrorMessage.Visible = true;
                        LblErrorMessage.Text = errorMessage;
                        return;
                    }
                }
                //通知方法が2 = EMAILの場合はメールアドレスの入力を必須にする（電話番号と住所は必須にしない）
                else if (notiffcationMethod == 2)
                {
                    //メールアドレスの規約違反の判定
                    Boolean emailErrorResult = worshipService.IsValueEmail(email, out errorMessage);
                    if (!emailErrorResult)
                    {
                        LblErrorMessage.Visible = true;
                        LblErrorMessage.Text = errorMessage;
                        return;
                    }

                    //電話番号と住所に入力があったらフォーマットの確認だけ行う
                    if (!string.IsNullOrEmpty(phone1) || !string.IsNullOrEmpty(phone2) || !string.IsNullOrEmpty(phone3))
                    {
                        if (stringHelper.IsValidPhone(phone))
                        {
                            errorMessage = ErrorMessageConst.PHONE_IS_FORMAT_ERROR;
                            LblErrorMessage.Visible = true;
                            LblErrorMessage.Text = errorMessage;
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(postalCode))
                    {
                        if (stringHelper.IsValidPostalCode(postalCode))
                        {
                            errorMessage = ErrorMessageConst.POSTALCODE_IS_FORMAT_ERROR;
                            LblErrorMessage.Visible = true;
                            LblErrorMessage.Text = errorMessage;
                            return;
                        }
                    }
                }
                //通知方法が3 = 希望しないの場合は電話番号、メールアドレス、住所の入力を必須にしない
                else if (notiffcationMethod == 3)
                {
                    //メールアドレス、電話番号、住所に入力があったらフォーマットの確認を行う
                    if (!string.IsNullOrEmpty(emailAddress))
                    {
                        if (stringHelper.ValidateEmail(email))
                        {
                            errorMessage = ErrorMessageConst.INPUT_EMAIL_RULE;
                            LblErrorMessage.Visible = true;
                            LblErrorMessage.Text = errorMessage;
                            return;
                        }
                        if (!string.IsNullOrEmpty(phone1) || !string.IsNullOrEmpty(phone2) || !string.IsNullOrEmpty(phone3))
                        {
                            if (stringHelper.IsValidPhone(phone))
                            {
                                errorMessage = ErrorMessageConst.PHONE_IS_FORMAT_ERROR;
                                LblErrorMessage.Visible = true;
                                LblErrorMessage.Text = errorMessage;
                                return;
                            }
                        }
                        if (!string.IsNullOrEmpty(postalCode))
                        {
                            if (stringHelper.IsValidPostalCode(postalCode))
                            {
                                errorMessage = ErrorMessageConst.POSTALCODE_IS_FORMAT_ERROR;
                                LblErrorMessage.Visible = true;
                                LblErrorMessage.Text = errorMessage;
                                return;
                            }
                        }
                    }
                }
            }

            // ご家族の情報
            //true = 有 false = 無
            Boolean spouse = false;
            Boolean sibling = false;
            Boolean chiildren = false;
            Boolean others = false;

            if (RadioSpouseYES.Checked)
            {
                spouse = true;
            }
            else
            {
                spouse = false;
            }
            if (RadioSiblingsYES.Checked)
            {
                sibling = true;
            }
            else
            {
                sibling = false;
            }
            if (RadioChildrenYES.Checked)
            {
                chiildren = true;
            }
            else
            {
                chiildren = false;
            }
            if (RadioRelationshipYES.Checked)
            {
                others = true;
            }
            else
            {
                others = false;
            }

            //備考
            string note = TxtNote.Text;

            //初穂料を数値へコンバート
            int firstfruitsFeeVal = int.Parse(CmbFirstfruitsFee.Text);

            BtnAdd.Enabled = false;
            // FamilyDataView フォームをインスタンス化
            FamilyDataView familyDataView = new FamilyDataView();

            // 家族情報入力画面のデータを設定
            familyDataView.LastName = TxtLastName.Text;
            familyDataView.FirstName = TxtFirstName.Text;
            familyDataView.FullName = TxtLastName.Text + " " + TxtFirstName.Text;
            familyDataView.LastNameKana = TxtLastNameKana.Text;
            familyDataView.FirstNameKana = TxtFirstNameKana.Text;
            familyDataView.BirthDate = DateTime.Parse(TxtBirthDate.Text);
            familyDataView.Email = TxtEmailAddress.Text;
            familyDataView.Phone = TxtPhone1.Text + TxtPhone2.Text + TxtPhone3.Text;
            familyDataView.PostalCode = TxtPostalCode1.Text + TxtPostalCode2.Text;
            familyDataView.Pref = CmbPref.SelectedItem.ToString();
            familyDataView.City = TxtCity.Text;
            familyDataView.Street = TxtStreet.Text;
            familyDataView.Building = TxtBuilding.Text;
            familyDataView.Prayer = CmbPrayerType.SelectedItem.ToString();
            familyDataView.FirstfruitsFeeVal = int.Parse(CmbFirstfruitsFee.Text);
            familyDataView.NotiffcationMethod = notiffcationMethod; // GetNotificationMethod() は通知方法を取得するメソッドと仮定
            familyDataView.Note = TxtNote.Text;
            familyDataView.Show();

            BtnAdd.Enabled = false; // この行で現在のフォームの Add ボタンを無効にすることもできます
        }

        //法人の登録のボタン
        private void BtnCompanyAdd_Click(object sender, EventArgs e)
        {
            WorshipService worshipService = new WorshipService();

            //入力値の取得
            //組織・団体名、代表者氏名
            string companyName = TxtCompanyName.Text;
            string companyNameKana = TxtCompanyNameKana.Text;
            string presLastName = TxtPresLastName.Text;
            string presFirstName = TxtPresFirstName.Text;
            string presLastNameKana = TxtPresLastNameKana.Text;
            string presFirstNameKana = TxtPresFirstNameKana.Text;
            string space = " "; // 半角スペースを含む文字列を定義
            string fullName = presLastName + space + presFirstName;
            string fullNameKana = presFirstNameKana + space + presLastNameKana;

            //名前の規約違反の判定
            Boolean nameErrorResult = worshipService.IsValueName(companyName, companyNameKana, fullName, fullNameKana, out string errorMessage);
            if (!nameErrorResult)
            {
                LblErrorMessage.Visible = true;
                LblErrorMessage.Text = errorMessage;
                return;
            }

            //メールアドレス
            string emailAddress = TxtCompanyEmailAddress.Text;
            string domain = CmbCompanyDomain.Text;
            string email = emailAddress + domain;

            //電話番号
            string phone1 = TxtCompanyPhone1.Text;
            string phone2 = TxtCompanyPhone2.Text;
            string phone3 = TxtCompanyPhone3.Text;
            string phone = phone1 + phone2 + phone3;

            //郵便番号
            string postalCode1 = TxtCompanyPostalCode1.Text;
            string postalCode2 = TxtCompanyPostalCode2.Text;
            string postalCode = postalCode1 + postalCode2;

            //住所
            string pref = CmbCompanyPref.Text;
            string city = TxtCompanyCity.Text;
            string street = TxtCompanyStreet.Text;
            string building = TxtCompanyBuilding.Text;
            string address = pref + city + street + building;

            //祈願情報
            string prayer = TxtCompanyPrayerType.Text;
            string firstfruitsFee = TxtCompanyFirstfruitsFee.Text;

            //祈願の規則違反の判定
            Boolean prayerDataErrorResult = worshipService.IsValuePrayerData(prayer, firstfruitsFee, out errorMessage);
            if (!prayerDataErrorResult)
            {
                LblErrorMessage_Company.Visible = true;
                LblErrorMessage_Company.Text = errorMessage;
                return;
            }

            //通知方法
            int notiffcationMethod = 0;
            if (RadioCompanyNotificationMethod_HAGAKI.Checked)
            {
                notiffcationMethod = 0;
            }
            else if (RadioCompanyNotificationMethod_SMS.Checked)
            {
                notiffcationMethod = 1;
            }
            else if (RadioCompanyNotificationMethod_MAIL.Checked)
            {
                notiffcationMethod = 2;
            }
            else if (RadioCompanyNotificationMethod_NONE.Checked)
            {
                notiffcationMethod = 3;
            }

            StringHelper stringHelper = new StringHelper();
            //通知方法が0 = HAGAKIの場合は住所の入力を必須にする（電話番号とEMAI必須にはしない）
            if (notiffcationMethod == 0)
            {
                //郵便番号の規約違反の判定
                Boolean postalCodeErrorResult = worshipService.IsValuePostalCode(postalCode, out errorMessage);
                if (!postalCodeErrorResult)
                {
                    LblErrorMessage_Company.Visible = true;
                    LblErrorMessage_Company.Text = errorMessage;
                    return;
                }
                //住所の規約違反の判定
                Boolean addressErrorResult = worshipService.IsValueAddress(pref, city, street, out errorMessage);
                if (!addressErrorResult)
                {
                    LblErrorMessage_Company.Visible = true;
                    LblErrorMessage_Company.Text = errorMessage;
                    return;
                }

                //電話番号とEMAILに入力があった場合はフォーマット確認だけ行う（NULL判定は行わない）
                if (!string.IsNullOrEmpty(phone1) || !string.IsNullOrEmpty(phone2) || !string.IsNullOrEmpty(phone3))
                {
                    if (stringHelper.IsValidPhone(phone))
                    {
                        errorMessage = ErrorMessageConst.PHONE_IS_FORMAT_ERROR;
                        LblErrorMessage_Company.Visible = true;
                        LblErrorMessage_Company.Text = errorMessage;
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(emailAddress))
                {
                    if (stringHelper.ValidateEmail(email))
                    {
                        errorMessage = ErrorMessageConst.INPUT_EMAIL_RULE;
                        LblErrorMessage_Company.Visible = true;
                        LblErrorMessage_Company.Text = errorMessage;
                        return;
                    }
                }
            }
            //通知方法が1 = SMSの場合は電話番号の入力を必須にする（住所とEMAILは必須にしない）
            else if (notiffcationMethod == 1)
            {
                //電話番号の規約違反の判定
                Boolean phoneErrorResult = worshipService.IsValuePhone(phone, out errorMessage);
                if (!phoneErrorResult)
                {
                    LblErrorMessage_Company.Visible = true;
                    LblErrorMessage_Company.Text = errorMessage;
                    return;
                }
                //EMAIと住所に入力があった場合はフォーマット確認だけ行う（NULL判定は行わない）
                if (!string.IsNullOrEmpty(emailAddress))
                {
                    if (stringHelper.ValidateEmail(email))
                    {
                        errorMessage = ErrorMessageConst.INPUT_EMAIL_RULE;
                        LblErrorMessage_Company.Visible = true;
                        LblErrorMessage_Company.Text = errorMessage;
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(postalCode))
                {
                    if (stringHelper.IsValidPostalCode(postalCode))
                    {
                        errorMessage = ErrorMessageConst.POSTALCODE_IS_FORMAT_ERROR;
                        LblErrorMessage_Company.Visible = true;
                        LblErrorMessage_Company.Text = errorMessage;
                        return;
                    }
                }
            }
            //通知方法が2 = EMAILの場合はメールアドレスの入力を必須にする（電話番号と住所は必須にしない）
            else if (notiffcationMethod == 2)
            {
                //メールアドレスの規約違反の判定
                Boolean emailErrorResult = worshipService.IsValueEmail(email, out errorMessage);
                if (!emailErrorResult)
                {
                    LblErrorMessage_Company.Visible = true;
                    LblErrorMessage_Company.Text = errorMessage;
                    return;
                }
                //電話番号と住所に入力があったらフォーマットの確認だけ行う
                if (!string.IsNullOrEmpty(phone1) || !string.IsNullOrEmpty(phone2) || !string.IsNullOrEmpty(phone3))
                {
                    if (stringHelper.IsValidPhone(phone))
                    {
                        errorMessage = ErrorMessageConst.PHONE_IS_FORMAT_ERROR;
                        LblErrorMessage_Company.Visible = true;
                        LblErrorMessage_Company.Text = errorMessage;
                        return;
                    }
                }
                if (!string.IsNullOrEmpty(postalCode))
                {
                    if (stringHelper.IsValidPostalCode(postalCode))
                    {
                        errorMessage = ErrorMessageConst.POSTALCODE_IS_FORMAT_ERROR;
                        LblErrorMessage_Company.Visible = true;
                        LblErrorMessage_Company.Text = errorMessage;
                        return;
                    }
                }
            }
            //通知方法が3 = 希望しないの場合は電話番号、メールアドレス、住所の入力を必須にしない
            else if (notiffcationMethod == 3)
            {
                //メールアドレス、電話番号、住所に入力があったらフォーマットの確認を行う
                if (!string.IsNullOrEmpty(emailAddress))
                {
                    if (stringHelper.ValidateEmail(email))
                    {
                        errorMessage = ErrorMessageConst.INPUT_EMAIL_RULE;
                        LblErrorMessage_Company.Visible = true;
                        LblErrorMessage_Company.Text = errorMessage;
                        return;
                    }
                    if (!string.IsNullOrEmpty(phone1) || !string.IsNullOrEmpty(phone2) || !string.IsNullOrEmpty(phone3))
                    {
                        if (stringHelper.IsValidPhone(phone))
                        {
                            errorMessage = ErrorMessageConst.PHONE_IS_FORMAT_ERROR;
                            LblErrorMessage_Company.Visible = true;
                            LblErrorMessage_Company.Text = errorMessage;
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(postalCode))
                    {
                        if (stringHelper.IsValidPostalCode(postalCode))
                        {
                            errorMessage = ErrorMessageConst.POSTALCODE_IS_FORMAT_ERROR;
                            LblErrorMessage_Company.Visible = true;
                            LblErrorMessage_Company.Text = errorMessage;
                            return;
                        }
                    }
                }
            }
            //備考
            string note = TxtNote.Text;

            //初穂料を数値へコンバート
            int firstfruitsFeeVal = int.Parse(TxtCompanyFirstfruitsFee.Text);
 
            Boolean insertResult = worshipService.InsertFunctionCompany(companyName, companyNameKana,presFirstName, presLastName, presLastNameKana, presFirstNameKana, email, phone,
                postalCode, pref, city, street, building, prayer, firstfruitsFeeVal, notiffcationMethod, note, out errorMessage);

            if (!insertResult)
            {
                //登録に失敗しました。
            }
            //登録に成功
            MessageBox.Show("成功しました");
        }


        private void LinkLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AuthService authService = new AuthService();
            authService.Logout();
        }

        private void OnInactivityDetected(object sender, EventArgs e)
        {
            // 無操作の検出時に実行する処理をここに記述
            MessageBox.Show("一定時間無操作が続いたのでログアウトします。");
            AuthService authService = new AuthService();
            authService.Logout();
        }

        // Win32 APIのインポート
        [DllImport("USER32.DLL")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, UInt32 bRevert);
        [DllImport("USER32.DLL")]
        private static extern UInt32 RemoveMenu(IntPtr hMenu, UInt32 nPosition, UInt32 wFlags);

        // ［閉じる］ボタンを無効化するための値
        private const UInt32 SC_CLOSE = 0x0000F060;
        private const UInt32 MF_BYCOMMAND = 0x00000000;


    }
}
