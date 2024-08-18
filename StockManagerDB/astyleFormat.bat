echo off

set arg1=%1
echo arg1 is %arg1%

"C:\workspace\GitHub\StockManager\StockManagerDB\AStyle.exe" --style=allman --add-one-line-braces --max-code-length=80 --break-after-logical --indent-switches --convert-tabs --indent-namespaces --indent=tab=4 --pad-header --pad-comma --pad-oper --max-continuation-indent=80 --attach-closing-while --align-pointer=type --squeeze-ws --fill-empty-lines --squeeze-lines=1 %arg1%
echo Press Enter to exit...

