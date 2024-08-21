// SPDX-License-Identifier: Sharia
pragma solidity ^0.8.21;
import "./01_dysnomia.sol";
import "./interfaces/05b_zhenginterface.sol";

contract ZHOU is DYSNOMIA {
    string public constant Type = "ZHOU";

    ZHENG public Upsilon;
    uint64 public Xi;
    uint64 public Monopole;

    constructor(address ZhengContract) DYSNOMIA(unicode"VM Zhou", unicode"ZHOU", address(DYSNOMIA(ZhengContract).Xiao())) MultiOwnable(msg.sender) {
        Upsilon = ZHENG(ZhengContract);
        Upsilon.addOwner(address(this));

        Bao memory Theta;
        Theta.Phi = address(this);
        Theta.Mu = Alpha("Zheng Rod", "ZROD");
        SHA Cone = Upsilon.Eta().Beta("Yi Shio Cone", "ZCONE");
        SHIO ZhengShio = Upsilon.Eta().SHIOFactoryInterface().New(address(Theta.Mu), address(Cone), address(DYSNOMIA(ZhengContract).Xiao()));
        Theta.Mu.addOwner(address(ZhengShio));
        Cone.addOwner(address(ZhengShio));
        ZhengShio.addOwner(address(Upsilon));
        ZhengShio.addOwner(address(Upsilon.Eta()));
        Theta.Xi = Xiao.Random();
        ZhengShio.Generate(Theta.Xi, Xiao.Random(), Xiao.Random());
        Upsilon.Iodize(ZhengShio);
        Theta.Shio = address(ZhengShio);
        Theta.Ring = ZhengShio.Magnetize();
        Theta = Upsilon.Eta().React(Theta, Theta.Xi);
        Monopole = Theta.Omicron;
        Theta = Upsilon.InstallRod(Theta.Xi, Theta, Monopole);
        Xi = Theta.Xi;
        AddMarketRate(address(Upsilon), 1 * 10 ** decimals());
        AddMarketRate(address(Theta.Mu), 1 * 10 ** decimals());
        AddMarketRate(address(Cone), 1 * 10 ** decimals());
        AddMarketRate(Theta.Shio, 1 * 10 ** decimals());
        mintToCap();
    }

    function Alpha(string memory Name, string memory Symbol) public onlyOwners returns (SHA) {
        mintToCap();
        return Upsilon.Eta().SHAFactoryInterface().New(Name, Symbol, address(address(Xiao)));
    }

    function React(uint64 Iota) public returns (Bao memory) {
        Bao memory Theta = Upsilon.GetRodByIdx(Xi);        
        Theta = Upsilon.Eta().React(Theta, Iota);
        mintToCap();
        return Theta;
    }
}