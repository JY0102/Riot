using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Riot;

namespace 전적검색
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private string BeforeUser = string.Empty;

        #region 싱글톤
        public static MainViewModel Singletone { get; private set; } = null;
        //static MainViewModel()
        //{
        //    Singletone = new MainViewModel();
        //}
        #endregion

        #region OpenAPi
        private static string API_KEY = "RGAPI-4a0d282c-35c0-469a-9848-bff9f7e519f5";

        OpenApi api = null;
        #endregion

        #region 선택된 리스트
        public Match SelectedMatch
        {
            get => _selectedmatch;
            set { _selectedmatch = value; OnPropertyChanged(); }
        }
        private Match _selectedmatch;
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

        public string GameType
        {
            get { return _gametype; }
            set
            {
                if (_gametype != value)
                {
                    _gametype = value;
                    OnPropertyChanged(nameof(GameType));
                }
            }
        }
        private string _gametype;

        public ObservableCollection<Match> Matches
        {
            get { return _matches; }
            set
            {
                _matches = value;
                OnPropertyChanged(nameof(_matches));
            }
        }
        private ObservableCollection<Match> _matches = new ObservableCollection<Match>();
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
        }

        #region 기능
        public void SearchUser()
        {
            try
            {
                if (BeforeUser == GameName)
                    return;

                _matches.Clear();

                var match = api.Search(GameName, GameType, int.Parse(Count));
                BeforeUser = GameName;
                foreach (var item in match)
                {
                    _matches.Add(item.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                GameName = "검색실패 다시 검색해주세요";
                BeforeUser = null;
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
