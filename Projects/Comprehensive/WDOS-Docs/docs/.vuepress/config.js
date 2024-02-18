module.exports = {
    title: 'WDO-Script 官方文档',
    theme: 'vdoing',
    description: 'To build a nice world!',
    base: '/',
    themeConfig: {
        logo: 'https://source.catrol.cn/icons/Project/Catrol/WDOS/logo2-green.png',
        nav: [
            { text: '主页', link: '/' },
            { text: '概览', link: '/guide/' },
            { text: '使用', link: '/use/' },
            { text: '标准', link: '/std/' },
            { text: 'GitHub', link: 'https://github.com/Catrol-org/WDO-Script' },
            {
                text: '更多',
                items: [
                    { text: '捐赠', link: '/donate/' },
                    { text: '感谢', link: '/thanks/' }
                ]
            }
        ],
        sidebar: [
            ['/', '主页'],
            ['/guide/', '概览'],
            ['/use/', '使用'],
            ['/std/', '标准']
        ],
        sidebarDepth: 2,
        smoothScroll: true,
        displayAllHeaders: true,

        category: false,
        tag: false,
        archive: false,
        updateBar: { showToArticle: false },
        footer: { createYear: '2022', copyrightInfo: 'Catrol' }
    },
    markdown: {
        lineNumbers: true
    },
    head: [
        ['link', { rel: 'icon', type: "image/x-icon", href: "https://source.catrol.cn/icons/Project/Catrol/WDOS/logo2-green.png" }]
    ]
}