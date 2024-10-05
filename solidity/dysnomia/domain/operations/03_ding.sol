// SPDX-License-Identifier: Sharia
pragma solidity ^0.8.21;
import "../../01_dysnomia_v2.sol";
import "./interfaces/02b_cheoninterface.sol";

contract DING is DYSNOMIA {
    string public constant Type = "DING";

    CHEON public Cheon;

    constructor(address CheonAddress) DYSNOMIA("Dysnomia Ding", "DING", address(DYSNOMIA(CheonAddress).Xiao())) {
        Cheon = CHEON(CheonAddress);
        Cheon.Sei().Chan().Xie().Xia().Mai().Qi().Zuo().VAT().addOwner(address(this));
        addOwner(tx.origin);
        _mintToCap();
    }

    function Train(TRAIT Trait) public onlyOwners returns (uint256 Charge, uint256 UserQi, uint256 Omicron, uint256 Omega) {
        uint256 Hypogram;
        uint256 Epigram;
        uint256 Contour;
        TimeDeposit memory _t;
        (YUEINTERFACE Yue, , QIN memory Player) = Cheon.Sei().Chi();
        (Charge, UserQi, Omega) = Cheon.Sei().Chan().React(Player, Trait);
        Omicron = Yue.React(Trait);
        (Hypogram, Epigram) = Yue.Bar(Trait);
        _t = Cheon.Sei().Chan().Xie().Xia().Mai().GetQingDeposit(Player.Location.Waat());
        Contour = Cheon.Sei().Chan().Xie().Xia().Amplify(_t.amount, _t.timestamp);
        Omega = Xiao.modExp(Hypogram, Omega, Contour);
        Omicron = Xiao.modExp(Epigram, Omicron, Contour);
    }
}