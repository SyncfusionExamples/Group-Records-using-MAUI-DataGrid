# Group-Records-using-MAUI-DataGrid

This sample demonstrates how to group records using the MAUI DataGrid control within a .NET MAUI application.

## Sample

```xaml
<ContentPage.Resources>
    <ResourceDictionary>
        <local:CellStyleConverter x:Key="cellStyleConverter"/>
        <Style TargetType="datagrid:DataGridIndentCell">
            <Setter Property="Background"
                    Value="{Binding Source={RelativeSource Mode=Self},
                    Converter={StaticResource Key=cellStyleConverter}}">
            </Setter>
        </Style>
        <local:GroupConverter x:Key="groupConverter"/>
    </ResourceDictionary>
</ContentPage.Resources>

<datagrid:SfDataGrid x:Name="dataGrid"
                     ItemsSource="{Binding OrdersInfo}"
                     IndentColumnWidth="60"
                     GroupingMode="Multiple"
                     AllowGroupExpandCollapse="True">
    <datagrid:SfDataGrid.GroupColumnDescriptions>
        <datagrid:GroupColumnDescription ColumnName="Freight"
                                         Converter="{StaticResource groupConverter}"/>
    </datagrid:SfDataGrid.GroupColumnDescriptions>
</datagrid:SfDataGrid>
```

## Requirements to run the demo

To run the demo, refer to [System Requirements for .NET MAUI](https://help.syncfusion.com/maui/system-requirements)

## Troubleshooting:
### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion has no liability for any damage or consequence that may arise from using or viewing the samples. The samples are for demonstrative purposes. If you choose to use or access the samples, you agree to not hold Syncfusion liable, in any form, for any damage related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion's samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion's samples.
