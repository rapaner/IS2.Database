# IS2 Database
## *���� ������ ��� ��������������� ����� "��-2"*

������� �������� ���������� ��� ������ ��� �����������������, ��������������� � ���������� ������ ����������.

## ������ � ��������
��� ������ ���������� ��������� �����������:
- **Microsoft Visual Studio 2022 Community**, ���� � ������������� [�����](docs/.vsconfig)
- **pgAdmin** ��� ����������� � ������� ���� ������, [������������](https://www.pgadmin.org/download/)
- **PostgreSQL 12+**, [���������� �� ���������](https://postgrespro.ru/windows)

## �������

- **IS2.Database.Common** - ������ � ������ �������� � ��������
- **IS2.Database.ConfigurationData** - ������ � ���������������� ������ ������
- **IS2.Database.ManagementData** - ������ � �������������� ������ ������
- **IS2.Database.ProjectData** - ������ � ��������� ������ ������
- **IS2.Database.Tests** - ������ � �������

## ������������ ����������
- [Microsoft.EntityFrameworkCore](https://learn.microsoft.com/ru-ru/ef/core/) - ���������� ��� ������ � ����� ������
- [Microsoft.EntityFrameworkCore.Design](https://learn.microsoft.com/ru-ru/ef/core/) - ���������� ��� �������� ��������
- [Microsoft.EntityFrameworkCore.Tools](https://learn.microsoft.com/ru-ru/ef/core/) - ����������� ��� �������� �������� � ���������� ���� ������
- [Npgsql.EntityFrameworkCore.PostgreSQL](https://github.com/npgsql/efcore.pg) - ��������� PostgreSQL ��� EntityFramework

## ���������� ���� ������
���������� ������������ ��� ������� ������� ���� ������.  
� �������� ������� ����� ������������������ ��������� ManagementData.  
��� �������� ���� ������ �� ������� ����������:  
1. ������� ������ IS2.Database.ManagementData ����������� ��������. ������ ���� �� �������, � ���������� ������ ������� *Set as Startup project* ![����������� ������](docs/set_as_startup_project.png)
1. ������� Package Manager Console. ![�������](docs/package_manager_console.png)
1. ������� ������ IS2.Database.ManagementData �������� �� ���������. ![������ �� ���������](docs/default_project.png)
1. � ������� ������ ������� *Update-Database -Connection "Server=localhost;Port=5432;User Id=postgres;Password=passw0rd;Database=ConfigurationDataDB"*, ��� � �������� ������ ���� ������� ���������� ������ ����������� � ���� ������. ����� �������� ����� *-Verbose* ��� ���������� ������. ������ Enter �� ���������� ��� ���������� �������.
1. � ������ ������ ��������� ������ ����� �����:![���������� ��](docs/update_database.png)

## �������� ��������� � ����� ���� ������
��� ��������� ����� ���� ������ (��������, ���������� ������ �������) ����������:
1. ������ ��������� � ������������ �������� ��� �������� �����. �� ������ ��������� �������� ������� ��� ������. �������� ����� � ����� *Model*.![��������](docs/project_entity.png)
1. ��� ������ �������� ���� ������������ ��� ��. ��������� �������� �������� �������� �� [������](https://learn.microsoft.com/en-us/ef/ef6/modeling/code-first/fluent/types-and-properties).![������������](docs/project_configuration.png)
1. � Package Manager Console ������ ������� *Add-Migration NewMigration*, ��� ������ *NewMigration* ������ ������ ����������� �������� ��������. ��������� �������
1. � ������ ������ � ����� *Migration* �������� ����� ���� ��������.
1. ��������� ������� *Update-Database* ��� ���������� ������������ ����� ���� ������
  
��������� ������� Package Manager Console ����������� �� [������](https://learn.microsoft.com/en-us/ef/core/cli/powershell#add-migration).

## ������������� ������������
��� ���������� ������ ��������� ���������� ��������������� �����������. ����������� ��������� � ������ *Repositories* ������� �������.  
��� ����������� �� � ��������� �������� � ������ ������� ���� ����������� ����� *DependencyInjection* � �������� *AddConfigurationDataServices*,  *AddManagementDataServices* � *AddProjectDataServices*.  
[������](IS2.Database.ConfigurationData/appsettings.json) ����������������� �����, ������� ������ ���� � ���������.
