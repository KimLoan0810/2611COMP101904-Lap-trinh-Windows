# Lab 07 - Quản lý cửa hàng mini bằng WinForms (SDI, MDI và nhiều Form)

## Thông tin sinh viên

- Họ tên: Lê Thị Kim Loan
- MSSV: 49.01.103.045
- Lớp: 49.01.SPTIN.A

## Mô tả

Ứng dụng WinForms **ShopManagerMini** quản lý cửa hàng mini gồm nhiều Form: đăng nhập, Form chính dạng MDI Parent, quản lý sản phẩm, quản lý khách hàng và giới thiệu. Dữ liệu được lưu tạm trong bộ nhớ bằng `List<T>`.

## Công nghệ sử dụng

- C# WinForms
- .NET 8 (`net8.0-windows`)
- Visual Studio 2022
- Dữ liệu trong bộ nhớ (`List<T>`), chưa dùng SQL Server

## Chức năng

### Danh sách Form

| Form | Vai trò |
|---|---|
| `FrmLogin` | Đăng nhập, trả `DialogResult.OK` khi thành công |
| `FrmMain` | Form chính MDI Parent: MenuStrip, StatusStrip |
| `FrmProduct` | Quản lý sản phẩm (CRUD, DataGridView) |
| `FrmCustomer` | Quản lý khách hàng (CRUD, DataGridView) |
| `FrmAbout` | Giới thiệu ứng dụng và sinh viên |

### Đăng nhập
- Kiểm tra tài khoản mẫu.
- Bỏ trống username hoặc password: hiện cảnh báo.
- Sai tài khoản: hiện thông báo lỗi.
- Đúng: mở `FrmMain`, StatusStrip hiển thị tên người dùng, vai trò và thời gian hiện tại.

### Form chính MDI
- Menu **Hệ thống** (Đăng xuất, Thoát), **Danh mục** (Quản lý sản phẩm, Quản lý khách hàng), **Trợ giúp** (Giới thiệu).
- Form con mở bên trong `FrmMain`; nếu Form cùng loại đang mở thì kích hoạt Form cũ, không mở trùng.
- Thoát chương trình có hỏi xác nhận.

### Quản lý sản phẩm
- Thêm sản phẩm
- Sửa sản phẩm
- Xóa sản phẩm (có xác nhận)
- Làm mới danh sách
- Tìm kiếm sản phẩm theo mã hoặc tên
- Không cho thêm trùng mã; không cho đơn giá hoặc số lượng âm

### Quản lý khách hàng
- Thêm, sửa, xóa (có xác nhận), làm mới
- Tìm kiếm theo mã, tên hoặc số điện thoại
- Không cho trùng mã; số điện thoại chỉ gồm chữ số

## Cách chạy

1. Mở file `ShopManagerMini.sln` bằng Visual Studio 2022 (cần workload **.NET desktop development**).
2. Build solution (`Ctrl + Shift + B`).
3. Chạy project (`F5`).

## Cơ sở dữ liệu

Bài lab này **chưa kết nối SQL Server**, nên không có script database và không cần cấu hình connection string. Dữ liệu mẫu được khai báo trong `ShopManagerMini/Data/DataStore.cs` và sẽ mất khi tắt chương trình.

## Tài khoản demo

| Username | Password | Họ tên | Vai trò |
|---|---|---|---|
| admin | 123 | Quản trị viên | Admin |
| user | 123 | Nhân viên bán hàng | User |

## Cấu trúc project

```
ShopManagerMini/
|-- ShopManagerMini.sln
|-- ShopManagerMini/
|   |-- Models/
|   |   |-- User.cs
|   |   |-- Product.cs
|   |   |-- Customer.cs
|   |-- Data/
|   |   |-- DataStore.cs
|   |-- Forms/
|   |   |-- FrmLogin.cs
|   |   |-- FrmMain.cs
|   |   |-- FrmProduct.cs
|   |   |-- FrmCustomer.cs
|   |   |-- FrmAbout.cs
|   |-- Program.cs
|-- docs/
|   |-- screenshots/
|-- README.md
|-- TraLoiCauHoi.md
|-- .gitignore
```

## Hình ảnh minh họa

### 1. Đăng nhập

#### Màn hình đăng nhập
![Dang nhap](screenshots/1_dang_nhap.png)

#### Nhập sai tên đăng nhập hoặc mật khẩu
![Nhap sai](screenshots/2_nhap_sai_ten_hoac_mk.png)

#### Bỏ trống tên đăng nhập hoặc mật khẩu
![Bo trong](screenshots/3_bo_trong_ten_hoac_mk.png)

### 2. Form chính (MDI)

Menu **Danh mục** mở các Form con; StatusStrip hiển thị người dùng, vai trò và thời gian.

![Form main](screenshots/4_form_main.png)

### 3. Quản lý sản phẩm

#### Màn hình quản lý sản phẩm
![Quan ly san pham](screenshots/5_quan_ly_san_pham.png)

#### Thêm sản phẩm
![Them san pham](screenshots/6_them_sp.png)

#### Báo lỗi trùng mã sản phẩm
![Trung ma](screenshots/7_trung_ma_sp.png)

#### Báo lỗi đơn giá âm
![Don gia am](screenshots/8_don_gia_am.png)

#### Báo lỗi số lượng âm
![So luong am](screenshots/9_so_luong_am.png)

#### Sửa sản phẩm
![Sua san pham](screenshots/10_sua_sp.png)

#### Xóa sản phẩm (có xác nhận)
![Xoa san pham](screenshots/11_xoa_sp.png)

#### Tìm kiếm sản phẩm
![Tim san pham](screenshots/12_tim_sp.png)

### 4. Quản lý khách hàng

#### Màn hình quản lý khách hàng
![Quan ly khach hang](screenshots/13_quan_ly_KH.png)

#### Thêm khách hàng
![Them khach hang](screenshots/14_them_KH.png)

#### Sửa khách hàng
![Sua khach hang](screenshots/15_sua_KH.png)

#### Xóa khách hàng (có xác nhận)
![Xoa khach hang](screenshots/16_xoa_KH.png)

#### Tìm kiếm khách hàng
![Tim khach hang](screenshots/17_tim_KH.png)

### 5. Giới thiệu

![Gioi thieu](screenshots/18_gioi_thieu.png)

### 6. Xác nhận thoát chương trình

![Thoat chuong trinh](screenshots/19_thoat_chuong_trinh.png)

## Câu hỏi nộp kèm
## 1. SDI và MDI khác nhau như thế nào?
 
| | SDI (Single Document Interface) | MDI (Multiple Document Interface) |
|---|---|---|
| Cách tổ chức | Mỗi cửa sổ là một Form độc lập, không có Form cha chứa các Form khác | Có một Form cha (MDI Parent) chứa nhiều Form con (MDI Child) bên trong |
| Thiết lập | Dùng `Show()` hoặc `ShowDialog()` bình thường | Form cha: `IsMdiContainer = true`; Form con: `MdiParent = formCha` rồi `Show()` |
| Vị trí cửa sổ con | Nằm tự do trên màn hình | Chỉ hiển thị trong vùng làm việc của Form cha |
| Đóng, thu nhỏ | Mỗi Form độc lập | Đóng Form cha thì các Form con cũng đóng; thu nhỏ Form con nằm trong Form cha |
| Ví dụ | Notepad, Calculator | `FrmMain` chứa `FrmProduct`, `FrmCustomer`, `FrmAbout` trong bài lab này |
 
SDI phù hợp ứng dụng nhỏ, mỗi lần làm một việc. MDI phù hợp ứng dụng quản lý có nhiều màn hình cần mở cùng lúc.
 
## 2. Vì sao Form đăng nhập nên dùng ShowDialog()?
 
`ShowDialog()` mở Form dạng **modal**:
 
- Chương trình **dừng tại dòng gọi** cho đến khi Form đăng nhập đóng, người dùng không thể thao tác với phần khác của ứng dụng khi chưa đăng nhập.
- Trả về **`DialogResult`** (`OK` khi đăng nhập thành công, `Cancel` khi thoát), nên chỉ cần một câu điều kiện để quyết định có mở Form chính hay không.
Nếu dùng `Show()` (non-modal), code phía sau chạy tiếp ngay, Form chính có thể mở khi chưa đăng nhập và không có cách gọn để biết đăng nhập thành công hay chưa.
 
Trong `Program.cs`:
 
```csharp
using (var login = new FrmLogin())
{
    if (login.ShowDialog() == DialogResult.OK)
        Application.Run(new FrmMain(login.LoggedInUser!));
}
```
 
## 3. Dữ liệu user được truyền từ FrmLogin sang FrmMain bằng cách nào?
 
Truyền qua hai bước:
 
1. `FrmLogin` kiểm tra tài khoản trong `DataStore.Users`; nếu đúng thì lưu user vào property **`LoggedInUser`** rồi đặt `DialogResult.OK`.
2. `Program.cs` đọc `login.LoggedInUser` và truyền vào **constructor** `new FrmMain(user)`. `FrmMain` lưu vào biến `_currentUser` và hiển thị tên, vai trò lên StatusStrip (`lblUser`, `lblRole`).
```csharp
// FrmLogin
public User? LoggedInUser { get; private set; }
...
LoggedInUser = user;
DialogResult = DialogResult.OK;
 
// FrmMain
public FrmMain(User user)
{
    InitializeComponent();
    _currentUser = user;
}
```
 
## 4. Nếu người dùng bấm menu sản phẩm nhiều lần, chương trình xử lý như thế nào để không mở trùng Form?
 
Hàm `OpenChildForm<T>()` duyệt qua danh sách `MdiChildren` của Form cha:
 
- Nếu đã có Form cùng kiểu (`child is T`): khôi phục nếu đang thu nhỏ, gọi `Activate()` để đưa lên trước rồi `return`, không tạo Form mới.
- Nếu chưa có: tạo Form mới, gán `MdiParent = this` và `Show()`.
```csharp
private void OpenChildForm<T>() where T : Form, new()
{
    foreach (Form child in MdiChildren)
    {
        if (child is T)
        {
            if (child.WindowState == FormWindowState.Minimized)
                child.WindowState = FormWindowState.Normal;
            child.Activate();
            return;
        }
    }
    T newForm = new T();
    newForm.MdiParent = this;
    newForm.Show();
}
 
private void mnuProduct_Click(object sender, EventArgs e) => OpenChildForm<FrmProduct>();
```
 
Khi đóng Form con rồi bấm menu lần nữa thì Form mới được tạo lại, vì lúc đó nó không còn trong `MdiChildren`.
 
## 5. Khi nào nên dùng constructor, khi nào nên dùng property để truyền dữ liệu giữa các Form?
 
| | Constructor | Property |
|---|---|---|
| Dùng khi | Dữ liệu **bắt buộc** để Form hoạt động và đã biết ngay lúc tạo Form | Dữ liệu **tùy chọn**, hoặc gán/đọc **sau khi** Form đã tạo, hoặc cần **lấy kết quả trả về** |
| Ưu điểm | Không thể quên truyền dữ liệu; Form luôn ở trạng thái hợp lệ | Linh hoạt, gán từng phần, đọc lại kết quả sau `ShowDialog()` |
| Lưu ý | Form cần constructor không tham số nếu mở bằng `new T()` hoặc muốn Designer hiển thị được | Có thể quên gán nên cần kiểm tra `null` |
| Trong bài lab | `FrmMain(User user)`: Form chính cần biết người dùng ngay từ đầu | `FrmLogin.LoggedInUser`: lấy kết quả sau khi đăng nhập xong |
 