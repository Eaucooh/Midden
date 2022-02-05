#include "efi.h"
#include "common.h"

#define MAX_COMMAND_LEN 100

void sep(void){
    for(int i = 1; i <= 50; ++ i) puts(L"-");
    puts(L"\r\n");
}

void game_snake(void){

}

void efi_main(void *ImageHandle __attribute__((unused)), struct EFI_SYSTEM_TABLE *SystemTable){
    efi_init(SystemTable);
    ST->ConOut->ClearScreen(ST->ConOut);

    unsigned short com[MAX_COMMAND_LEN];

    int isRunning = TRUE;

    while(isRunning){
        puts(L"# > ");
        if (gets(com, MAX_COMMAND_LEN) <= 0) continue;

        if (!strcmp(L"hello", com)){ // 你好
            puts(L"@ > Hello Cassion UEFI!\r\n");
        }else if(!strcmp(L"whoami", com)){ // 辨别用户
            puts(L"@ > What's your name? > ");
            gets(com, MAX_COMMAND_LEN);
            if(!strcmp(L"catrol", com)){
                puts(L"@ > You're my father!\r\n");
                continue;
            }else puts(L"@ > I don't konw you.\r\n");
        }else if(!strcmp(L"info", com)){ // 输出信息
            puts(L"@ > UEFI Program\r\n");
            puts(L"@ > UEFI for CassionCore\r\n");
            puts(L"@ > Copyright © Catrol 2021\r\n");
            sep();
            puts(L"@ > You can type 'help' to get more infos.\r\n");
            sep();
            puts(L"@ > Your Computer : \r\n");
            puts(L"@ > CPU --> \r\n");
            puts(L"@ > RAM --> \r\n");
        }else if(!strcmp(L"game", com)){ // 进入游戏模式
            int isGaming = TRUE;
            unsigned short name[MAX_COMMAND_LEN];
            while(isGaming){
                puts(L"G > ");
                if(gets(name, MAX_COMMAND_LEN) <= 0) continue;

                if(!strcmp(L"exit", name)){
                    isGaming = FALSE;
                }else if(!strcmp(L"ls", name)){
                    puts(L"snake\r\n");
                    puts(L"error\r\n");
                }else if(!strcmp(L"snake", name)){
                    game_snake();
                }else puts(L"Game not found.\r\n");
            }
        }else if(!strcmp(L"algorithm", com)){ // 算法模式
            int isCalcing = TRUE;
            unsigned short name[MAX_COMMAND_LEN];
            while(isCalcing){
                puts(L"A > ");
                if(gets(name, MAX_COMMAND_LEN) <= 0) continue;

                if(!strcmp(L"exit", name)){
                    isCalcing = FALSE;
                }else if(!strcmp(L"ls", name)){
                    puts(L"P57\r\n");
                }else if(!strcmp(L"P57", name)){
                    
                }else puts(L"Algorithm not found.\r\n");
            }
        }else if(!strcmp(L"exit", com)){ // 软关机
            puts(L"\r\n\r\nPress any key to shutdown ...");
            getc();
            isRunning = FALSE;
            ST->RuntimeServices->ResetSystem(EfiResetShutdown, EFI_SUCCESS, 0, NULL);
        }
        else puts(L"Command not found.\r\n"); // 没找到命令
    }
}
