Startup -- ����ASP.NET Core����������

	Program.cs
		main��������������� CreateHostBuilder ������CreateHostBuilder ����ֵΪ IHostBuilder
		
		IHostBuilder	
			Ӧ�ó����ʼ������ӿڣ�������Ӧ�ó��������ĺ��Ľӿ�


	�������̣�Program��Startup�ࣩ��
		1��ConfigureWebHostDefaults
			��һ�׶Σ�����׶�ע����Ӧ�ó����Ҫ�ļ�����������磺����������������
		2��ConfigureHostConfiguration
			�ڶ��׶Σ���������Ӧ�ó�������ʱ��Ҫ�����ã����磺Ӧ�ó�������ʱ��Ҫ�����Ķ˿ڡ�URL��ַ��������������ǿ���Ƕ�������Լ����������ݣ�ע�뵽���ÿ����ȥ��
		3��ConfigureAppConfiguration
			�����׶Σ�����������Ƕ�������Լ��������ļ���Ӧ�ó����ȡ�������ý����ͻ���Ӧ�ó���ִ�й����м乩ÿ�������ȡ
		4��ConfigureServices --> ConfigureLogging --> Startup --> Startup.ConfigureServices
			���Ľ׶Σ���Щ����������������������ע�����ǵ�Ӧ�õ����
		5��Startup.Configure
			����׶Σ�����ע�������Լ����м��������HttpContext������������̵�
		
		
	Startup�࣬��Ӧ�ó������������ǷǱ���ģ�ֻ��Ϊ�������ǵĴ���ṹ������
		���·���ͬStartup������һ�£���Program��� CreateHostBuilder �����У�
		webBuilder.ConfigureServices(...);
		webBuilder.Configure(...);

	Startup.ConfigureServices
		ͨ����������ע����������Ҫ�ķ��񣬸�ʽ���ƣ�services.AddXXX()��

	Startup.Configure
		����ͨ����������������Ҫע����Щ�м�������������ȥ��