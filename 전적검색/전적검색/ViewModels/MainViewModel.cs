using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Riot;

namespace 전적검색
{
    internal class MainViewModel : INotifyPropertyChanged
    {

        #region 싱글톤
        public static MainViewModel Singletone { get; private set; } = null;
        //static MainViewModel()
        //{
        //    Singletone = new MainViewModel();
        //}
        #endregion

        #region OpenAPi
        private static string API_KEY = "RGAPI-fa5239b4-8970-40c0-a7bf-167abf66a355";

        OpenApi api = null;
        #endregion

        #region DataBase

        public Database DB { get; set; } = null;

        public DataDragon Dragon { get; set; } = null;
        #endregion

        #region 선택된 리스트
        public MatchJson SelectedMatch
        {
            get => _selectedmatch;
            set { _selectedmatch = value; OnPropertyChanged(); }
        }
        private MatchJson _selectedmatch;
        #endregion

        #region 저장, 수정시 사용하는 속성(게임 이름 , 출력개수 , 타입 , match)
        public string GameName
        {
            get => _gamename;
            set { _gamename = value; OnPropertyChanged(); }
        }
        private string _gamename = "또내가못해서졌네#321";

        public string Count
        {
            get => _count;
            set { _count = value; OnPropertyChanged(); }
        }
        private string _count = "5";

        public object GameType
        {
            get
            {
                if (_gametype == null)
                    return "";
                else if (_gametype.ToString() != "All")
                    return _gametype;
                else
                    return "";

            }
            set { _gametype = ((ComboBoxItem)value).Content; OnPropertyChanged(); }
        }
        private object _gametype;

        public ObservableCollection<MatchJson> Matches
        {
            get { return _matches; }
            set
            {
                _matches = value;
                OnPropertyChanged(nameof(Matches));
            }
        }
        private ObservableCollection<MatchJson> _matches = new ObservableCollection<MatchJson>();
        #endregion

        #region 속성 변경시 호출되는 통지 이벤트
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        #endregion

        #region Action 정의(생성자 초기화)
        public ICommand SearchCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        #endregion

        public MainViewModel()
        {
            Singletone = this;

            api = new OpenApi();
            api.AddKey(API_KEY);


            SearchCommand = new RelayCommand(SearchUser);
            //UpdateCommand = new RelayCommand(UpdateMember, () => SelectedMember != null);
            //DeleteCommand = new RelayCommand(DeleteMember, () => SelectedMember != null);

            DB = new Database();
            Dragon = new DataDragon(DB.SpellTable, DB.RuneTable);
            DB.UpdateAll();
        }

        #region 기능

        private string BeforeUser = string.Empty;
        private string BeforeType = string.Empty;

        public void SearchUser()
        {
            try
            {
                if (BeforeUser == GameName && BeforeType == GameType?.ToString())
                    return;

                Matches.Clear();

                var match = api.Search(GameName, GameType?.ToString() ?? "", int.Parse(Count));
                foreach (var item in match)
                {
                    Matches.Add(item);
                }

                BeforeUser = GameName;
                BeforeType = GameType.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GameName = "검색실패 다시 검색해주세요";
            }
        }
        public void UpdateMember()
        {

        }
        public void DeleteMember()
        {

        }
        #endregion
    }
}
