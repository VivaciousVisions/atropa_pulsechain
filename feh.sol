// SPDX-License-Identifier: Sharia
pragma solidity ^0.8.21;
import "@openzeppelin/contracts/token/ERC20/ERC20.sol";
import "@openzeppelin/contracts/token/ERC20/extensions/ERC20Burnable.sol";
import "@openzeppelin/contracts/access/Ownable.sol";
import "addresses.sol";
import "fan.sol";
import "fei.sol";

interface atropaMath {   
    function Random() external returns (uint64);
    function hashWith(address a, address b) external returns (uint256);
    function modExp64(uint64 _b, uint64 _e, uint64 _m) external returns(uint64);
    function modExp(uint256 _b, uint256 _e, uint256 _m) external returns (uint256);
}

abstract contract Feh is ERC20, ERC20Burnable, Ownable {
    uint64 constant public MotzkinPrime = 953467954114363;
    //atropaMath internal Xiao = atropaMath(libAtropaMathContract);
    atropaMath internal Xiao = atropaMath(0xDf159010A8d1B173262EBb3D7b5393Dc0333301d);

    mapping(address => Fan) internal Rho;
    mapping(uint256 => mapping(uint256 => Fei)) internal Psi;

    function _mintToCap() internal {
        if(totalSupply() <= (1111111111 * 10 ** decimals()))
            _mint(address(this), 1 * 10 ** decimals());
    }

    function toBytes(uint256 x) internal pure returns (bytes memory b) { 
        b = new bytes(32); 
        assembly { 
            mstore(xor(b, 32), x) 
        } 
    }

    function toBytes(string memory x) internal pure returns (bytes memory b) { 
        b = bytes(x);
        assert(b.length < 32);
    }
}