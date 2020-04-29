<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HeyOrder.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <link rel="icon" href="Z9rYrnh.ico" type="image/x-icon" />
    <title>首頁</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css" integrity="sha384-9gVQ4dYFwwWSjIDZnLEWnxCjeSWFphJiwGPXr1jddIhOegiu1FwO5qRGvFXOdJZ4" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/malihu-custom-scrollbar-plugin/3.1.5/jquery.mCustomScrollbar.min.css">
    <link rel="stylesheet" href="CSS1.css">

    <script src="bootstrap-4.0.0-dist/js/bootstrap.js"></script>
    <script defer src="https://use.fontawesome.com/releases/v5.0.13/js/solid.js" integrity="sha384-tzzSw1/Vo+0N5UhStP3bvwWPq+uvzCMfrN1fEFe+xBmv1C/AtVX5K0uZtmcHitFZ" crossorigin="anonymous"></script>
    <script defer src="https://use.fontawesome.com/releases/v5.0.13/js/fontawesome.js" integrity="sha384-6OIrr52G08NpOFSZdxxz1xdNSndlD4vdcf/q2myIUVO0VsqaGHJsB0RaBE01VTOY" crossorigin="anonymous"></script>
</head>
<body>
    <div class="wrapper">
        <!-- Sidebar  -->
        <nav id="sidebar">
            <div id="dismiss">
                <i class="fas fa-arrow-left"></i>
            </div>
            <div class="sidebar-header">
                <div style="text-align: center;">
                    <img src="https://i.imgur.com/Z9rYrnh.png" width="60%" />
                    <br />
                    <h3>HeyOrder
                        <br />
                        後台管理系統</h3>
                </div>
            </div>
            <ul class="list-unstyled components">
                <li>
                    <a href="Default.aspx">首頁</a>
                </li>
                <li>
                    <a href="MbrList.aspx">會員資料管理</a>
                </li>
                <li>
                    <a href="ShopList.aspx">店家資料管理</a>
                </li>
                <li>
                    <a href="MeList.aspx">餐點資料管理</a>
                </li>
                <li>
                    <a href="OrList.aspx">訂單資料管理</a>
                </li>
                <li>
                    <a href="DeList.aspx">明細資料管理</a>
                </li>

                <li>
                    <a href="AdmList.aspx">管理員資料管理</a>
                </li>

            </ul>

        </nav>

        &nbsp;&nbsp;&nbsp;

         <div id="content">

             <nav class="navbar navbar-expand-lg navbar-light bg-light">
                 <div class="container-fluid">
                     <button type="button" id="sidebarCollapse" class="btn btn-info">
                         <i class="fas fa-align-left"></i>
                         <span></span>
                     </button>
                     <div class="collapse navbar-collapse" id="navbarSupportedContent">
                     </div>
                 </div>
             </nav>

             <form id="form1" runat="server">
                 <div style="text-align: center;">
                     <img src="https://i.imgur.com/Z9rYrnh.png" width="20%" />
                     <h1>Hey!Order</h1>
                     <br />
                     <h4>你還在慢慢排隊點餐嗎?</h4>
                     <h4>趕快來使用Hey!Order讓你比別人提早一步吃飯</h4>
                     <br />
                     <h5>We will make your life more convenient.</h5>
                     <br />
                 </div>
             </form>
         </div>

    </div>
    <div class="overlay"></div>
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js" integrity="sha384-cs/chFZiN24E4KMATLdqdvsezGxaGsi4hLGOzlXwp5UZB1LY//20VyM2taTB4QvJ" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js" integrity="sha384-uefMccjFJAIv6A+rW+L4AHf99KvxDjWSu1z9VI8SKNVmz4sk7buKt/6v9KI65qnm" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/malihu-custom-scrollbar-plugin/3.1.5/jquery.mCustomScrollbar.concat.min.js"></script>



    <script type="text/javascript">
        $(document).ready(function () {
            $("#sidebar").mCustomScrollbar({
                theme: "minimal"
            });

            $('#dismiss, .overlay').on('click', function () {
                $('#sidebar').removeClass('active');
                $('.overlay').removeClass('active');
            });

            $('#sidebarCollapse').on('click', function () {
                $('#sidebar').addClass('active');
                $('.overlay').addClass('active');
                $('.collapse.in').toggleClass('in');
                $('a[aria-expanded=true]').attr('aria-expanded', 'false');
            });
        });
    </script>

</body>
</html>
