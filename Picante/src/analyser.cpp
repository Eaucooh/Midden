#include <bits/stdc++.h>
using namespace std;
// string - name | int - type ; string - value
map<string, string> vars;
queue<string> var_names;
// trim_start - 去掉开头字符
string trim_start(string start, char tar), trim_end(string start, char tar);
// typeCheck - 检查变量类型
int typeCheck(string value);
// zoneCheck - 检查名称合法性
bool zoneCheck(char c){
    return (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9') || c == '_';
}
void printAllVars(){
    printf("\nEnabled vars viewing ::: \n");

    int len = var_names.size();
    for(int i = 0; i < len; ++ i){
        string name = var_names.front();
        printf("%s | %s\n", var_names.front().c_str(), vars[var_names.front()].c_str());
        cout << name << " | " << vars[name] << endl;
        var_names.push(var_names.front());
        var_names.pop();
    }
    
    // if(!vars.empty())
    //     for(auto i = vars.begin(); i != vars.end(); ++ i)
    //         cout << i->first << " | " << i->second << endl;
}
// 语句分析
void analyse(string now){
    now = trim_start(now, ' '); // 去掉开头空格
    now = trim_end(now, ' '); // 去掉结尾空格
    
    string front, second; int i, cmd_type = -1;
    for(i = 0; i < now.length(); ++ i){
        if(now[i] == ' ' || now[i] == '=') break;
        else front += now[i];
    }
    for(; i < now.length(); ++ i){
        if(now[i] == '='){
            cmd_type = 0; // 赋值语句类型
            for(int j = i + 1; j < now.length(); ++ j)
                second += now[j];
            second = trim_start(second, ' ');
            second = trim_end(second, ' ');
            break;
        }
    }

    switch(cmd_type){
        case 0:
            vars[front] = second;
            var_names.push(front);
            break;
    }
}
// 去掉开头字符
string trim_start(string start, char tar){
    if(start[0] != tar) return start;
    int i; string rst;
    for(i = 0; i < start.length(); ++ i) if(start[i] != tar) break;
    for(; i < start.length(); ++ i) rst += start[i];
    return rst;
}
// 去掉开头字符
string trim_end(string start, char tar){
    if(start[start.length() - 1] != tar) return start;
    int i; string rst;
    for(i = start.length() - 1; i >= 0; ++ i) if(start[i] != tar) break;
    for(; i >= 0; ++ i) rst += start[i];
    return rst;
}
// 检查变量类型
int typeCheck(string value){
    return 0;
}