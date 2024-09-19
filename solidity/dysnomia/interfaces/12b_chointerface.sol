// SPDX-License-Identifier: Sharia
pragma solidity ^0.8.21;
import "../include/user.sol";
import "./01b_dysnomia.sol";
import "./11b_lauinterface.sol";
import "./libstrings.sol";
import "./libcorereactions.sol";

interface CHOINTERFACE {
    function Rename(string memory newName, string memory newSymbol) external;
    function GetMarketRate(address _a) external view returns(uint256);
    function Purchase(address _t, uint256 _a) external;
    function Redeem(address _t, uint256 _a) external;
    function name() external view returns (string memory);
    function symbol() external view returns (string memory);
    function decimals() external view returns (uint8);
    function totalSupply() external view returns (uint256);
    function balanceOf(address account) external view returns (uint256);
    function transfer(address to, uint256 value) external returns (bool);
    function allowance(address owner, address spender) external view returns (uint256);
    function approve(address spender, uint256 value) external returns (bool);
    function transferFrom(address from, address to, uint256 value) external returns (bool);
    function addOwner(address newOwner) external;
    function renounceOwnership(address toRemove) external;
    function owner(address cOwner) external view returns (bool);
    function mintToCap() external;
    function Type() external view returns (string memory);
    function Prime() external view returns (uint256);
    function Void() external view returns (VOID);
    function Saat(uint256) external view returns (uint64);
    function On() external view returns (Bao memory);
    function Shio() external view returns(SHIO);
    function Omicron() external view returns(uint64);
    function Omega() external view returns(uint64);
    function Entropy() external view returns (uint64);
    function Addresses(string memory) external view returns (address);
    function Qu(uint256) external view returns (address);
    function Aliases(uint256) external view returns (string memory);
    function AddSystemAddress(string memory Alias, address Address) external;
    function AddLibraryOwner(string memory what) external;
    function CYUN() external view returns(LIBSTRINGS);
    function Reactor() external view returns(LIBCOREREACTIONS);
    function Luo() external returns (uint256);
    function VerifyUserTokenPermissions(address UserToken) external;
    function Enter(address UserToken) external returns(User memory);
    function GetUser() external returns(User memory Alpha);
    function GetUserSoul() external view returns(uint64);
    function GetUserBySoul(uint64 Soul) external returns (User memory Alpha);
    function GetUserByAddress(address who) external returns(User memory Alpha);
    function GetAddressBySoul(uint64 soul) external view returns(address UserAddress);
    function GetUserTokenAddress(address wallet) external view returns(address UserToken);
    function Log(uint64 Soul, uint64 Aura, string memory LogLine) external;
    function OperatorSendMSG(string memory chatline) external;
    function React(uint64 Eta) external returns (uint64, uint64);
    function ReactUser(uint64 Soul, uint64 Epsilon) external returns (uint64, uint64);
}