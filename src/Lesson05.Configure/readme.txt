���ÿ�ܣ��÷����޷���Ӧ���ֻ���


���������
    Microsoft.Extensions.Configuration.Abstractions
    Microsoft.Extensions.Configuration

���÷�ʽ
    ͨ������key-value�ַ�����ֵ�Եķ�ʽ�������ã�JSON/XML��
    ֧�ִӸ��ֲ�ͬ����Դ��ȡ����(�����С������������ļ���)

��������
    IConfiguration:
    IConfigurationRoot:���õĸ������ж�ȡ������Ķ����������������
    IConfigurationSection:��ָ���÷���ڵ㣬ÿһ����ð����Ϊ�ָ���
    IConfigurationBuilder:����Ӧ�ó������õĺ���,���е����ö���builder�����

������չ��
    IConfigurationSource
    IConfigurationProvider
    ͨ����չ��ָ����������õ�������Դ��ע�뵽���
        


�����в������÷�ʽ -- ��򵥿�ݵ�����ע�뷽��
    ��������Microsoft.Extensions.Configuration.CommandLine

    ֧�ֵ������ʽ
        ��ǰ׺ key=value ģʽ
        ˫�к���ģʽ --key=value ���� --key value
        ��б��ģʽ /key=value �� /key value
        ��ע���Ⱥŷָ����Ϳո�ָ������ܻ���
    
    �����滻ģʽ��Ϊ�������ñ�����        
        �����Ե�����(-)��˫����(--)��ͷ
        ӳ���ֵ䲻�ܰ����ظ�Key
        

���������������÷�ʽ  -- ��������������ע������;��
    ��������Microsoft.Extensions.Configuration.EnvironmentVariables

    ���ó���
        ��Docker������ʱ
        ��Kubernetes������ʱ
        ��Ҫ����ASP.NET Core��һЩ������������ʱ
    ����
        �������õķֲ㽡��֧����˫�»���"__"����":"
        ֧�ָ���ǰ׺����
    ǰ׺����
        ��ָ��ע�뻷��������ʱ��ָ��һ��ǰ׺����ֻ��ע������ָ��ǰ׺�Ļ�����������������еĻ�������ע�����


�����������������ص�
    ������������û��������ʱ��һ������ϵͳ�����ж��Ӧ�ó�������Ӧ�ó���ע�����õķ�ʽһ�㶼��ͨ���ļ����������еķ�ʽ��ע��ģ������еķ�ʽʹ�õ�Ҳ�Ǽ��١�
    ���ڣ����������Ļ����£�����Docker�ĸ�����������ζ��ÿ��Ӧ�ó����൱������һ��������С�Ͳ���ϵͳ��һ����
    ����Docker�ṩ�Ļ������������������ǿ���ʹ�û����������������ǵ�Ӧ�ó���
    ��Docker��Kubernetes�У����ǻ������ʹ�û���������������ʹ�����������������ǵĻ������á�
        


�ļ������ṩ���� -- ����ѡ�����õĸ�ʽ
    ����������ȡ��ͬ�ļ���ʽ�����߲�ͬλ������ȡ�����ļ�
        Microsoft.Extensions.Configuration.Ini
        Microsoft.Extensions.Configuration.Json
        Microsoft.Extensions.Configuration.NewtonsoftJson
        Microsoft.Extensions.Configuration.Xml
        Microsoft.Extensions.Configuration.UserSecrets

    ����
        �ļ��ṩ����֧��ָ���ļ���ѡ����ѡ
        ֧��ָ���Ƿ�����ļ��ı��
        ����ӵ��������ȼ����ߣ��Ḳ��ǰ����ӵ�����
    

���������ļ���� -- �����ȸ��������ĺ���

    ����
        ��Ҫ��¼����Դ���ʱ
        ��Ҫ����������ʱ�����ض�����ʱ

    �������ùؼ�����
        λ�������ռ䣺Microsoft.Extensions.Primitives;
        IChangeToken token = IConfiguration.GetReloadToken();
        token.RegisterChangeCallback(state=>{
            var root = (ConfigurationRoot)state;
        }, configurationRoot);

        �÷�ʽ����ֻ�ܴ���һ�Σ�����������ӣ���Ҫ�ڱ��ʱ���»�ȡ token ��ע�����ص� RegisterChangeCallback
        ����ʹ�� ChangeToken.OnChange()���������������ļ��仯
        


���ð� -- ʹ��ǿ���Ͷ��������������
    ���ð���Microsoft.Extensions.Configuration.Binder
    Ҫ��
        ֧�ֽ����ð󶨵����ж���
        ֧�ֽ����ð󶨵�˽��������  
     


�Զ�����������Դ -- �ͳɱ�ʵ�ֶ��ƻ����÷���
    ��չ����
        ʵ�� IConfigurationSource
        ʵ�� IConfigurationProvider
        ʵ�� AddXXX��չ����
    