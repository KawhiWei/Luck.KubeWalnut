using Luck.KubeWalnut.Adapter.KubernetesAdaper;
using Luck.KubeWalnut.Application.Clusters;
using Luck.KubeWalnut.Domain.AggregateRoots.Clusters;
using Luck.KubeWalnut.Dto.Kubernetes;
using Microsoft.AspNetCore.Mvc;

namespace Luck.KubeWalnut.Api.Controllers;

/// <summary>
/// 集群管理
/// </summary>
[Route("api/clusters")]
public class ClusterController : BaseController
{
    private readonly IClusterApplication _clusterApplication;
    public ClusterController(IClusterApplication clusterApplication)
    {
        _clusterApplication = clusterApplication;
    }

    // [HttpPost]
    // public async Task CreateCluster()
    // {
    //
    //     await _clusterApplication.CreateClusterAsync();
    // }

    [HttpGet]
    public async Task<KubernetesClusterOutputDto> GetNodeListAsync()
    {
//         await _kubernetesResource.GetNameSpaceListAsync(@"apiVersion: v1
// clusters:
// - cluster:
//     certificate-authority-data: LS0tLS1CRUdJTiBDRVJUSUZJQ0FURS0tLS0tCk1JSUREekNDQWZlZ0F3SUJBZ0lVSHJqaENXVlRzdE1iWTZ6RlNqYTk2RHYwai9Fd0RRWUpLb1pJaHZjTkFRRUwKQlFBd0Z6RVZNQk1HQTFVRUF3d01NVEF1TVRVeUxqRTRNeTR4TUI0WERUSXlNRGN5TmpFeU5EWTBORm9YRFRNeQpNRGN5TXpFeU5EWTBORm93RnpFVk1CTUdBMVVFQXd3TU1UQXVNVFV5TGpFNE15NHhNSUlCSWpBTkJna3Foa2lHCjl3MEJBUUVGQUFPQ0FROEFNSUlCQ2dLQ0FRRUF3ak92dWpzeWdzTVZQQk0vOHptZ0x4Uzc1UXVOemMrWTlzL2gKenJOcTBxSStnZjBNdEN0OGZIRlM2WWpiVGxIYmxOMGxUVlE5QjlJT1FXSCsyRUcwY3N4U3l4bThsUkJ4cHQ5cAp5am1NdE14eVl2RDU2TEdwb05zOGNZa2NEaC9La3ZuYS9qLzh0ZEdFb3VXZEczcmlHWGhyU0tmV0pTbVRxOVlXCiswL3NHME05bTlCeldQdmZ4ejRvWXVHK25IcWxrY2EzZ1VRMStkTzdabzE1MkhodWQ1QlBkMjB3Ym51TWFPM0kKaDA5U2ZGMHRFczROazQ1RVlzZDlEZ3h3NDV4SWVmOHNLRUZDOElIQ1BsZTVEQ1VxNkE0elR3MWVNQnpUaElHbAo0b2xUTU8xd3BkTEVIZ2tRV0dTWGtKUGt5OFdQRXRlNm5ONGoyc292Wis2VkFRZ3ZjUUlEQVFBQm8xTXdVVEFkCkJnTlZIUTRFRmdRVVNzNWhnZ1dna1Q1UEdKZzhQZUM2WmkydExpNHdId1lEVlIwakJCZ3dGb0FVU3M1aGdnV2cKa1Q1UEdKZzhQZUM2WmkydExpNHdEd1lEVlIwVEFRSC9CQVV3QXdFQi96QU5CZ2txaGtpRzl3MEJBUXNGQUFPQwpBUUVBUmQ5VEppTDFKYXBreTN0QUVqYkt0WDZ3ZjN5dFF0dzV4cTIrME1TcnhZejl0OVEvbk0rL2dJUE5xZmFyCjltbkNkUGxCczg1SzU3Ym1lTHRwNXRpcWxjcHgyOTJidlc2aHc4dGx2ME5zTG1kN1VCYXZQSUswVUN5TG4xTjEKaGp0cVY3S0VpYlBCajlZenF4QWc0Z05ianFLWTRlL2VKRGJWTUhWTzMrQkVpRzhLZXE4QUdTdGhSY1FpWHltbQpKVXZENElBWFZqWFA2VWY4S1ZYd2tManRaU29BaXR0ZENmKytpV3RUUHI2SmZzaUlCeCt3Q2g2cnlVV0pCQTZvCnh2aVBYWGczT2wvMGl3akd2Q25DTUtqVXJSeTRDVXJLOUdwbm1USENSYW5zQ21EdmNkenZLTnREclltU3c3eU0KUkdUM3dUdDJWNEVqdXJMc25OUXlzcjI1SlE9PQotLS0tLUVORCBDRVJUSUZJQ0FURS0tLS0tCg==
//     server: https://47.100.213.49:8325
//   name: microk8s-cluster
// contexts:
// - context:
//     cluster: microk8s-cluster
//     user: admin
//   name: microk8s
// current-context: microk8s
// kind: Config
// preferences: {}
// users:
// - name: admin
//   user:
//     token: allQK2FaT3JyeGorM3VRMUJEOVpFeHBmbWtPR1BheTBxbkdGR2w0R1Vudz0K");
//         
        
        return await _clusterApplication.GetClusterInformationAsync( @"apiVersion: v1
clusters:
- cluster:
    certificate-authority-data: LS0tLS1CRUdJTiBDRVJUSUZJQ0FURS0tLS0tCk1JSUREekNDQWZlZ0F3SUJBZ0lVSHJqaENXVlRzdE1iWTZ6RlNqYTk2RHYwai9Fd0RRWUpLb1pJaHZjTkFRRUwKQlFBd0Z6RVZNQk1HQTFVRUF3d01NVEF1TVRVeUxqRTRNeTR4TUI0WERUSXlNRGN5TmpFeU5EWTBORm9YRFRNeQpNRGN5TXpFeU5EWTBORm93RnpFVk1CTUdBMVVFQXd3TU1UQXVNVFV5TGpFNE15NHhNSUlCSWpBTkJna3Foa2lHCjl3MEJBUUVGQUFPQ0FROEFNSUlCQ2dLQ0FRRUF3ak92dWpzeWdzTVZQQk0vOHptZ0x4Uzc1UXVOemMrWTlzL2gKenJOcTBxSStnZjBNdEN0OGZIRlM2WWpiVGxIYmxOMGxUVlE5QjlJT1FXSCsyRUcwY3N4U3l4bThsUkJ4cHQ5cAp5am1NdE14eVl2RDU2TEdwb05zOGNZa2NEaC9La3ZuYS9qLzh0ZEdFb3VXZEczcmlHWGhyU0tmV0pTbVRxOVlXCiswL3NHME05bTlCeldQdmZ4ejRvWXVHK25IcWxrY2EzZ1VRMStkTzdabzE1MkhodWQ1QlBkMjB3Ym51TWFPM0kKaDA5U2ZGMHRFczROazQ1RVlzZDlEZ3h3NDV4SWVmOHNLRUZDOElIQ1BsZTVEQ1VxNkE0elR3MWVNQnpUaElHbAo0b2xUTU8xd3BkTEVIZ2tRV0dTWGtKUGt5OFdQRXRlNm5ONGoyc292Wis2VkFRZ3ZjUUlEQVFBQm8xTXdVVEFkCkJnTlZIUTRFRmdRVVNzNWhnZ1dna1Q1UEdKZzhQZUM2WmkydExpNHdId1lEVlIwakJCZ3dGb0FVU3M1aGdnV2cKa1Q1UEdKZzhQZUM2WmkydExpNHdEd1lEVlIwVEFRSC9CQVV3QXdFQi96QU5CZ2txaGtpRzl3MEJBUXNGQUFPQwpBUUVBUmQ5VEppTDFKYXBreTN0QUVqYkt0WDZ3ZjN5dFF0dzV4cTIrME1TcnhZejl0OVEvbk0rL2dJUE5xZmFyCjltbkNkUGxCczg1SzU3Ym1lTHRwNXRpcWxjcHgyOTJidlc2aHc4dGx2ME5zTG1kN1VCYXZQSUswVUN5TG4xTjEKaGp0cVY3S0VpYlBCajlZenF4QWc0Z05ianFLWTRlL2VKRGJWTUhWTzMrQkVpRzhLZXE4QUdTdGhSY1FpWHltbQpKVXZENElBWFZqWFA2VWY4S1ZYd2tManRaU29BaXR0ZENmKytpV3RUUHI2SmZzaUlCeCt3Q2g2cnlVV0pCQTZvCnh2aVBYWGczT2wvMGl3akd2Q25DTUtqVXJSeTRDVXJLOUdwbm1USENSYW5zQ21EdmNkenZLTnREclltU3c3eU0KUkdUM3dUdDJWNEVqdXJMc25OUXlzcjI1SlE9PQotLS0tLUVORCBDRVJUSUZJQ0FURS0tLS0tCg==
    server: https://47.100.213.49:8325
  name: microk8s-cluster
contexts:
- context:
    cluster: microk8s-cluster
    user: admin
  name: microk8s
current-context: microk8s
kind: Config
preferences: {}
users:
- name: admin
  user:
    token: allQK2FaT3JyeGorM3VRMUJEOVpFeHBmbWtPR1BheTBxbkdGR2w0R1Vudz0K");
    }
}