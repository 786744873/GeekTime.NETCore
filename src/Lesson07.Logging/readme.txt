��־��� -- ���ļ���־���������

    ������
        Microsoft.Extensions.Logging
        Microsoft.Extensions.Logging.Console
        Microsoft.Extensions.Logging.Debug
        Microsoft.Extensions.Logging.TraceSource
        
    ��־����
        ���س̶ȴӵ͵��ߣ�Trace��Debug��Information��Warning��Error��Critical��None
        ֵ�ֱ��ǣ�0~6
        
    ��־�����ȡ
        ILoggerFactory ��ʽ��ȡ
        ILogger<T> ǿ���ͷ���ģʽ��ȡ
        
    ��־���˵������߼�    
        ������־���ƣ�������־������𡢿��ص�

    ��־�������
        ����־�ı���ʽ��ʱ����Ҫע�⡣
        _logger.LogInformation($"Show Time {DateTime.Now}")�����뷽��ǰ���Ƚ����ڸ�ʽ����ƴ���ַ���
        _logger.LogInformation("Show Time {time}", DateTime.Now)�������־ʱ���Ż�ȥ���ڸ�ʽ����ƴ���ַ���
        
        ���õڶ���ռλ����ʽʱ������־�趨�˸߼�����ô�ͼ�����־�л�ʡ�Ը�ʽ���ַ������裬��ʡ��Դ����


��־������ -- �����ͬ����֮�����־����
    ����������
        appsettings������ "IncludeScopes": true,
    ����
        һ�����������������ʱ
        �������̵���־����ʱ
        ������׷������������̶�Ӧʱ

    һ������£������Ƽ���һ��Ψһ�ı�ʶ����ʶ�������� HTTP �����Id��Session��Id���Ự��Id�������Id
    
    Console��־ ���ڲ����첽ʵ��